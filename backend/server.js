const path = require("path");
require("dotenv").config({ path: path.resolve(process.cwd(), "config", ".env") });

const fs = require("fs");
const pg = require("pg");

const pool = new pg.Pool({
  user: "htn2020pp",
  password: process.env.COCKROACH_DB_PASSWORD,
  host: "spiffy-beaver-8bb.gcp-northamerica-northeast1.cockroachlabs.cloud",
  database: "defaultdb",
  port: 26257,
  ssl: {
    ca: fs.readFileSync(path.resolve(process.cwd(), "config", "spiffy-beaver-ca.crt")).toString()
  }
});

async function getUsers() {
  const client = await pool.connect();
  let users;
  try {
    const res = await client.query("SELECT * FROM Users");
    users = res.rows;
  } finally {
    client.release();
  }
  return users;
}

async function addUser(username, passwordHash, salt) {
  const client = await pool.connect();
  try {
    const res = await client.query("INSERT INTO Users (username, password, salt) VALUES ($1, $2, $3)",
      [ username, passwordHash, salt ]);
  } finally {
    client.release();
  }
}

const crypto = require("crypto");

function encrypt(password, salt) {
  return crypto.scryptSync(password, salt, 64).toString("base64");
}

const app = require("express")();
const helmet = require("helmet");
const jwt = require("jsonwebtoken");
const bodyParser= require("body-parser");

app.use(helmet());
app.use(bodyParser.json());

app.get("/", (req, res) => {
  res.send("Hello, World!");
});

app.post("/create-user", (req, res) => {
  const { username, password } = req.body;
  console.log("Received create user request for user " + username + " at " + new Date().toISOString());

  const salt = crypto.randomBytes(64).toString("base64");
  const hash = encrypt(password, salt);

  addUser(username, hash, salt);

  console.log("Added user " + username + " at " + new Date().toISOString());

  res.sendStatus(200);
});

app.post("/login", (req, res) => {
  const { username, password } = req.body;
  console.log("Received login request for user " + username + " at " + new Date().toISOString());
  getUsers().then(users => {
    const requestedUser = users.find(user =>
      user.username === username && user.password === encrypt(password, user.salt));

    if (requestedUser) {
      const token = jwt.sign({ username: requestedUser.username }, process.env.ACCESS_TOKEN_SECRET, { expiresIn: "2d" });
      res.send({ uuid: requestedUser.id, token: token });
    } else {
      res.send("Username or password incorrect");
    }
  });
});

const authenticateJwt = (req, res, next) => {
  const authHeader = req.headers.authorization;
  if (authHeader) {
    const token = authHeader.split(" ")[1];
    jwt.verify(token, process.env.ACCESS_TOKEN_SECRET, (err, user) => {
      if (err) {
        return res.sendStatus(403);
      }

      req.user = user;
      next();
    })
  } else {
    res.sendStatus(401);
  }
}

const https = require("https");

app.get("/get-location", authenticateJwt, (req, res) => {
  console.log("Authorized user " + req.user.username);
  https.get("https://maps.googleapis.com/maps/api/geocode/json?address=" + req.query["search"] + "&key=" + process.env.GOOGLE_API_KEY, (resp) => {
    let data = "";
    resp.on("data", (chunk) => {
      data += chunk;
    });
    resp.on("end", () => {
      res.send(JSON.parse(data).results[0].geometry.location);
    });
  }).on("error", (err) => {
    console.log("Google API error: " + err);
    res.sendStatus(500);
  })
});

app.listen(process.env.PORT || 3000, () => console.log("Server started..."));
