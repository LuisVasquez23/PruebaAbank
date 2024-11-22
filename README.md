# Abank API

## Descripción

Esta es una API RESTful construida con **.NET 8**, utilizando **Clean Architecture** y **CQRS y mediator** para manejar comandos y consultas. Proporciona funcionalidades para gestionar usuarios, como creación, actualización, eliminación y recuperación de datos.

## Dependencias

Este proyecto requiere las siguientes dependencias:

1. **.NET 8 SDK**: El framework para construir y ejecutar la API.
   - Instalación: [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. **PostgreSQL**: Base de datos utilizada para almacenar los datos de los usuarios.
   - Instalación: [postgresql.org/download](https://www.postgresql.org/download/)
3. **Docker** (opcional): Para ejecutar PostgreSQL en un contenedor.
   - Instalación: [docker.com](https://www.docker.com/)

---

## Pasos para Descargar el Repositorio

1. **Clonar el repositorio**:
   Abre la terminal o línea de comandos y ejecuta:
   ```bash
   git clone <url-del-repositorio>
   cd <nombre-del-repositorio>
   ```
2. Abrir la solución en Visual Studio 2022

3. Crear la base de datos siguiente las instrucciones del archivo **README.md** en la carpeta **Base de datos**.

4. Cuando ya esté creada la base de datos, seleccionar como se va a ejecutar la aplicación si http, https o mediante docker. Si se va ejecutar con docker cambiar la ruta del servidor para que conecte con el contenedor del servicio de la base de datos. Para saber la ip del contenedor usar el siguiente comando: 

    ```bash 
        docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' postgres_server
    ```

    - Si se ejecuta con http o https, sirve con poner local host en la cadena de conexión

5- Ejecutar la aplicación 


