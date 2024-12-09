# Proyecto Restaurante: Laboratorio Web servidor

Presentacion del trabajo Final de la materia Laboratorio web servidor

## Correr de forma local

Clonar el proyecto

```bash
  git clone https://github.com/f-antonelli/api-la-comanda.git
```

Una vez clonado, ingresar al proyecto

```bash
  cd /api-la-comanda
```

Para abrir el proyecto en visual studio

```bash
  Abrir visual studio y ejecutar el archivo /api-la-comanda/Restaurante.sln
```

Generar una base de datos local (sql server) y colocar el string de conexion

```bash
  Ingresar a appsettings.json y ingresar su string de conexion en ConnectionStrings
```

Correr el proyecto

```bash
  Ctrl + F5
```

Correr la migracion desde la consola del administrador de paquetes

```bash
  update-database
```

## Utilizar POSTMAN

Dentro de la carpeta /api-la-comanda/postman se encuentra la coleccion del proyecto

```bash
  Descargar coleccion e importar la misma en postman
```

Configurar el baseUrl dentro de las variables de entorno para poder utilizar la coleccion

```bash
  https://localhost:7176
```

## Login referencias

```http
  POST /api/Login
```

Usuarios utiles

| Usuario      | Password     | Rol         |
| ------------ | ------------ | ----------- |
| `bartender1` | `bartender1` | `bartender` |
| `cervecero1` | `cervecero1` | `cervecero` |
| `cocinero1`  | `cocinero1`  | `cocinero`  |
| `mozo1`      | `mozo1`      | `mozo`      |
| `admin1`     | `admin1`     | `admin`     |
