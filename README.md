# Single Agenda

<p align="center">
<a href="#"><img src="https://travis-ci.org/laravel/framework.svg" alt="Build Status"></a>
<a href="#"><img src="https://poser.pugx.org/laravel/framework/license.svg" alt="License"></a>
</p>

## About SingleAgenda
Hi there! Thank you for your time and take a look for a moment for this project. SingleAgenda was the name, I don't know why, but it works.
I invite you my friend to analyse this code, database and running application.
Questions about the architecture, how to install and some conventions, I'll explain below.
Regards and one more time, thank you for the opportunity!

## Nomenclature definition and conventions
I've defined a single conventions for this project (I always have this in mind). You 

## Database Conventions
To avoid problems with names and the pattern of tables, I conventioned that all tables have a minimum structure, that you can see in the imagem below:
<center><img src="https://user-images.githubusercontent.com/1747058/110218028-35ef4700-7e96-11eb-9012-c9a7ef30c640.png" /></center>

- One unique key per table (Except for N to N situations, but not applicable on this project).
- CreatedAt, UpdatedAt and Removed fields, part of convetions to audit the data.
- The delete methods will only make the logical delete. The data will be kept on the table.

## Architecture

## Tests Layers and TDD approach
Most of the crytical parts and importants conventions to check, I used the TDD approach.
Not only to develop and refactoring moments (you can see in all commits that the state of objects had changed during the development and this is a little custome that I maintain in all the projects that I do, evolve my code always). 
Finally, this one will help us on deploy the application, to ensure that all implementations are ok.


## License
Open-sourced software licensed under the [MIT license] (https://opensource.org/licenses/MIT).
