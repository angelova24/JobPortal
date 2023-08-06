# JobPortal

## Table of Contents

- [Description](#description)
- [Installation](#installation)


## Description

JobPortal is a course project for my studies at [SoftUni](https://softuni.bg/)
and is a simple solution for searching and uploading job offers and also for reading articles.

## Installation

- Clone to a local directory\
  `git clone https://github.com/angelova24/JobPortal.git`
- Open JobPortal-CourseProject.sln in Visual Studio/Rider
- Change the connectionString in Program.cs file
- Apply all migration and then run the project
- You must now have the seeded admin user with
  - Email: admin@test.com
  - Password: admin1234
- In order to have the seeded job offers you have to:
  - register an user
  - go in DB and manually add employer with ID: AA294071-5C7D-4F4C-8451-42FAC506957C
  - eventually you have to apply the migrations again
