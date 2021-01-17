FROM node:14-slim

WORKDIR /usr/src/app
COPY package*.json ./

RUN npm install --only=production

ADD . ./

CMD [ "node", "server.js" ]
