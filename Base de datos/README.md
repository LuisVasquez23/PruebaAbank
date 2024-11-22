# Configuración de la Base de Datos para el Proyecto

Este proyecto hace uso de docker para tener una instancia de PostgreSQL

---

## Requisitos previos

Requerimientos:

- **Docker**: para ejecutar el contenedor de PostgreSQL.
- **Cliente PostgreSQL**: como `psql`, DBeaver o pgAdmin, para conectarte al servidor.

---

## Pasos para configurar la base de datos

### 1. Crear el contenedor de PostgreSQL

Ejecuta el siguiente comando en tu terminal para crear y ejecutar un contenedor con PostgreSQL:

```bash
docker run -d --name postgres_server -p 5432:5432 -e POSTGRES_PASSWORD=luis23032002 postgres
```

### 2. Crear la base de datos `Abank` en DBeaver

1. Abre **DBeaver** e inicia sesión en tu servidor PostgreSQL:

   - **Username**: `postgres`
   - **Password**: `luis23032002`

2. Una vez conectado al servidor, crea una nueva base de datos:

   - Haz clic derecho sobre la conexión de tu servidor en el panel izquierdo.
   - Selecciona **SQL Editor > Open SQL Script**.
   - En el editor SQL, escribe el siguiente comando:

     ```sql
     CREATE DATABASE Abank;
     ```

3. Verificar que la base de datos se haya creado:
   - Haz clic derecho en la conexión y selecciona **Refresh**.

### 3. Crear la tabla `users` en DBeaver

1. Asegurarse que está conectado a la base de datos `Abank`:

   - Busca la base de datos `Abank`.
   - Haz clic derecho sobre `Abank` y selecciona **Seleccionar por defecto** para trabajar en ella.

2. En el editor SQL, copiar y pegar el siguiente script para crear la tabla `users`:

   ```sql
   CREATE TABLE users (
       id SERIAL PRIMARY KEY,
       first_name VARCHAR(100) NOT NULL,
       last_name VARCHAR(100) NOT NULL,
       date_of_birth DATE NOT NULL,
       address TEXT NOT NULL,
       password VARCHAR(120) NOT NULL,
       phone VARCHAR(15) NOT NULL,
       email VARCHAR(100) NOT NULL UNIQUE,
       created_at TIMESTAMP NOT NULL DEFAULT NOW(),
       updated_at TIMESTAMP NULL
   );
   ```

   y ejecutar el script

3. Verificar que la tabla se haya creado correctamente:

   - En el panel izquierdo, expande Abank > Schemas > public > Tables. Deberías ver la tabla users listada.

### 4. Insertar un usuario de ejemplo para iniciar sesion en la aplicación

1. En el editor SQL, copiar y pegar el siguiente script para insertar un usuario de ejemplo:

   ````sql
   INSERT INTO public.users
   (id, first_name, last_name, date_of_birth, address, "password", phone, email, created_at, updated_at)
   VALUES
   (1, 'admin', 'admin', '2002-03-12', 'El Salvador', 'admin', '12345678', 'admin@admin', '2024-11-22 12:18:41.921', NULL);```

   ````

2. Verifica que el usuario haya sido insertado correctamente, ejecutando el siguiente comando:

   ````sql
   SELECT * FROM users;```
   ````
