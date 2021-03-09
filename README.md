# Single Agenda

<p align="center">
<a href="#"><img src="https://travis-ci.org/laravel/framework.svg" alt="Build Status"></a>
<a href="#"><img src="https://poser.pugx.org/laravel/framework/license.svg" alt="License"></a>
</p>

## About SingleAgenda
Hi there! Thank you for your time to analyse for a moment for this project. SingleAgenda was the name, I don't know why ... but I invite you to take this experience. 
How to install and some conventions, I'll explain bellow. 
Best regards!

## Setup the Projects
To setup the Single Agenda is very easy and I'll show you how properly setup it.

### Backend
All the Backend is in .NET Core version 3.1 and to setup this, you just need to run the build and will be done.
If you don't have the .NET Core 3.1, here is the link:

https://dotnet.microsoft.com/download

After all builded, just run the project and this will open the environment of API on this url: http://localhost:53539

### Database migration
Its not necessary to execute the Update-Database command to dump the database because the project will setup in the first time that the service will be accessed.

### Frontend

Prerequisites:
- Latest version of NodeJs  installed (https://nodejs.org/dist/v14.16.0/node-v14.16.0-x64.msi);
- Angular Cli version 10 (I'll show you how to setup bellow)

### Installing the Angular Environment
Let's execute the commands inside the CMD Prompt:
<code>npm install -g @angular/cli@10.0.2</code>

After all done, execute inside the folder "web-portal" the command:
<code>npm install</code>
(this will install all packages and dependences of Angular project

Now, execute the server with the command:
<code>ng serve</code>

![image](https://user-images.githubusercontent.com/1747058/110416837-2842e880-8073-11eb-8288-1ae7399f6a30.png)

If all things is ok, you can access the frontend project in the url localhost:4200:
![image](https://user-images.githubusercontent.com/1747058/110416891-3db81280-8073-11eb-93a8-054045e2bf3f.png)

Remember, to access the portal, I setup a default user and password:
User: admin@admin
Password: 123456

Enjoy!

## Nomenclature definition and conventions
I've defined a single conventions for this project (I always keep this in mind). You will note on the structure this caracteristics:
- Kamel case to classes names, variables, and so on.
- Table name like the application context (using the code-first approach)

## Database Conventions
To avoid problems with names and the pattern of tables, I conventioned that all tables have a minimum structure, that you can see in the imagem below:
<center><img src="https://user-images.githubusercontent.com/1747058/110218028-35ef4700-7e96-11eb-9012-c9a7ef30c640.png" /></center>

- One unique key per table (Except for N to N situations, but not applicable on this project).
- CreatedAt, UpdatedAt and Removed fields, part of convetions to audit the data.
- The delete methods will only make the logical delete. The data will be kept on the table.

## Architecture

### Repositories Layer
I started the project making a generic operation for CRUD (IRepository), but writing the tests and seeing the results, it not worth and I prefer modify the responsability, for the business rules layer (Application). The code I'll maintain in the project, because maybe be util.

## Tests Layers and TDD approach
Most of the crytical parts and importants conventions to check, I used the TDD approach.
Not only to develop and refactoring moments (you can see in all commits that the state of objects had changed during the development and this is a little custome that I maintain in all the projects that I do, evolve my code always). 
Finally, this one will help us on deploy the application, to ensure that all implementations are ok.


## License
Open-sourced software licensed under the [MIT license] (https://opensource.org/licenses/MIT).
