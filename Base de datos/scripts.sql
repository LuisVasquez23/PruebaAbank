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


INSERT INTO public.users
(id, first_name, last_name, date_of_birth, address, "password", phone, email, created_at, updated_at)
VALUES(1, 'admin', 'admin', '2002-03-12', 'El Salvador', 'admin', '12345678', 'admin@admin', '2024-11-22 12:18:41.921', NULL);