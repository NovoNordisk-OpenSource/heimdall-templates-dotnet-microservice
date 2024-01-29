# heimdall-microservice-template
Generic .NET Microservice template for Heimdall capabilities and other container based workloads

WIP = WORK IN PROGRESS

## Building container images
Build container images with the following command: docker-compose build --build-arg GITHUB_TOKEN={GITHUB_PAT_WITH_PACKAGE_READ_SCOPE_ON_NOVO_NORDISK_OPENSOURCE_ORG}

## Setup database

### Start database
Initialize database using: docker-compose up database

### Apply migrations
In a seperate terminal do the following: 

cd src\Heimdall.Templates.Dotnet.Microservice.Infrastructure
dotnet ef database update
cd ..\..\

### Stop database
Once migration completes run: docker-compose stop database


## Start applications
To bootstrap application without Kafka-support (Worker + Kafka stuff) run the following command: docker-compose up database host.api

To bootstrap application with Kafka-support (Worker + Kafka stuff) run the following command: docker-compose -f docker-compose.kafka.yml -f docker-compose.yml up