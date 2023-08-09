# JobPortal

## Table of Contents

- [Description](#description)
- [Installation](#installation)


## Description

JobPortal is a course project for my studies at [SoftUni](https://softuni.bg/).\
It is a simple solution for searching and uploading job offers and also for reading articles.\
Users can apply for jobs by uploading CV, they also can become employers.\
Employers are users which can upload and manage job offers and see all appliers and their CVs.\
Admins can only mange the job offers and upload and manage articles.

## Installation

- Clone to a local directory\
  `git clone https://github.com/angelova24/JobPortal.git`
- Open JobPortal-CourseProject.sln in Visual Studio/Rider
- Change the connectionString in Program.cs file
- Apply all migrations and then run the project
- You must now have in DB:
  - Admin user with:
    - Email: admin@test.com
    - Password: admin1234
  - Employer user with:
    - Email: employer@test.com
    - Password: 123456
  - Seeded 3 jobs and 2 articles
