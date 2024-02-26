

## Requisitos

- Asegúrate de tener Docker instalado en tu máquina local. Puedes verificar la instalación ejecutando el comando docker -v. Se recomienda utilizar Docker version 25.0.2
- Asegúrate de tener Node.js instalado en tu máquina local. Puedes verificar la instalación ejecutando el comando node -v. Se recomienda utilizar Node.js version 20.11.1.

# API Terrawind

Este proyecto contiene el Docker para la API de Terrawind.

## Pasos para ejecutar el Docker API Terrawind

1. Clona este repositorio en tu máquina local usando `git clone https://github.com/crissando/solucion-terrawind.giturl_del_repositorio`.

2. Ingresa el directorio raiz `/solucion-terrawind` y crea la imagen docker `docker build -t api-terrawind -f api-terrawind\Dockerfile .`

3. Crea un contenedor Docker con el siguiente comando: `docker run -d -p 32773:8080 -p 32774:8081 api-terrawind`.

4. Para validar que todo esa bien ir a la siguiente url `https://localhost:32768/api/cryptocurrency`.

# Landing Bitcoin Main

Este proyecto contiene el Docker para la app landing-bitcoin-main.

## Pasos para ejecutar el Docker API Terrawind

1. Ingresa el directorio raiz `/solucion-terrawind/landing-bitcoin-main`.

2. Instala `npm install`. esto creara la carperta `node_modules`

3. Inicia la aplicación en local. `npm run dev`

4. Para validar que todo esa bien ir a la siguiente url `https://localhost:5173`.


