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
<center><img src="https://previews.dropbox.com/p/thumb/ABGLlOqPhZeBiIH08BEzESXXgTtqqsemfHfoYKne1QeJuskshdMjOzM6VQEH5DvlWyN4sVXsphO-F00YYTTQ4tStSZ5Ri_rS8dSvjYFvp5Rl3MD_vrCi1NKfBADK7WxnLe6kqVpJ8MkKlT1slQAfypjeAkbmrh8C56fPUhPBzYKxqB9CtKbaSL3yV8M1kTbL9TKqCcvhNCt7OL9AHWoQGk_2Y_39WEFce3sMSqSAGwMxdGUegeBtaG4xRjcuklCRKNWcPZMvJvAE9FIRO7ExcwcDrZAUz6QO3XRol5dojZ65OfVmvlkm2rY9mYyZqqun-LZqqyNJaR7iK91a2QTs7ZlnfJCLuGJxzhIGe65DwhbP3g/p.jpeg?fv_content=true&size_mode=5" /></center>

- One unique key per table (Except for N to N situations, but not applicable on this project).

## Architecture

## Tests Layers and TDD approach
Most of the crytical parts and importants conventions to check, I used the TDD approach.
Not only to develop and refactoring moments (you can see in all commits that the state of objects had changed during the development and this is a little custome that I maintain in all the projects that I do, evolve my code always). 
Finally, this one will help us on deploy the application, to ensure that all implementations are ok.


## License
Open-sourced software licensed under the [MIT license] (https://opensource.org/licenses/MIT).
