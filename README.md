# BuyMyHouse
The end assigment of the subject cloud databases

## Setup
The project is setup for local usage.

## Redis usage
The usage of a redis cache has been chosen, because the mortgage offers only have to be available temporarily.

### Redis configuration
To download redis for docker execute the command: `docker pull redis`
Then run the container, and change te redis connection string in appsettings.json

## Email client
The email client in the project works, however some configuration has to be done.

### Email client configuration
Change the fields EmailAddress, EmailPassword and EmailClient in appsettings.json to run the email client.
