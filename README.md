# vrspike
The best Spikeball Game of all time! IN VR

## Inspiration

Let's face it: a healthy exercise regimen was hard enough to maintain during pre-COVID times, and with 2020 being the age of the couch potato, motivation to stay fit is at an all-time low. Doing squats and push-ups in the corner of the basement isn't just lonely, it isn't even fun. Unfortunately, social distancing and lockdown have prevented us from exercising by playing our favourite sports with our closest friends. Wouldn't it be nicer if there was a more natural way to get you to exercise, without putting yourself at biological risk?

## What it does

We built a VR game that allows you to play the popular sport Spikeball - a game where teams take turns serving a ball across a trampoline using their hands. Be careful - it's deceptively easy! You'll not only need to refine your motor skills, but you'll probably be sweating soon since Spikeball will make you jump, duck, and swerve. And, here's the kicker - thanks to our valiant efforts, you can play with anyone across the world with a stable internet connection! 

## How we built it

The game itself was done in Unity and multiplayer functionality was included using the Photon networking framework. Assets were taken from the Unity Asset Store and fitted to our liking in the editor. The server, used for user credentials and querying 3rd party APIs, was developed in Node.js/Express.js alongside CockroachDB as our database system. We published these applications through Docker containers and Google Cloud Run to be available publicly.

## Challenges we ran into

In general, none of us have worked on VR before. We found many unique challenges - lack of good technical support due to extremely new technology, countless Unity crashes and untraceable errors, and sub-optimal support for lots of APIs and services. Implementing multiplayer was a huge challenge - though Photon streamlined the process, it was difficult getting real-time communication and object sharing going, and it took a large chunk of our development time. We had also planned on incorporating a speech recognition aspect in the project, however these libraries were very rare on the Unity VR platform. Seeing that speech recognition either had large fees associated with it or simply was not available for our use case, we unfortunately had to abandon the idea.

## Accomplishments that we're proud of

Although it's not perfect, we're proud to have made a game that resembles Spikeball to a surprising degree of accuracy! The game allows players to play together virtually in Virtual Reality and experience play in a way unseen during the COVID-19 pandemic and revitalize old friends that may have been starting to drift apart - and stay healthy while doing so! Not only that, if we managed to integrate the ability to play in different cities, to allow people to explore the world from home! The task of implementing real-time communication in VR was a daunting one for such a small time interval, but through perseverance and determination, we made it work!

## What we learned

We all learned extensive amounts about making VR games in Unity. From 3d modelling, to working with 3d physics, it was a new area of software development for most of us. We are glad to say that we have implemented real-time multiplayer, which was another major learning point for our group. It opened our eyes to the difficulties in syncing physics and 3D object movements between different clients, and the difficulty in managing such a game.

## What's next for SpikeWorld

There are many features we wanted to integrate but didn't have time to, and we would like to continue working on SpikeWorld to fully flesh it out. One such feature would have been ultimate moves - for example, being able to slow to time, reduce gravity, or change the size of the ball. We would also like to implement user experience gain, with leader-boards and eventual tournaments to showcase their skills.

