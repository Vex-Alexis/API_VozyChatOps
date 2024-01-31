# API_VozyChatOps

Este API proporciona funcionalidades para validar la actividad de un estudiante y generar el horario en formato PDF. Utiliza tecnologías modernas como .NET 6.0 y se integra con un servidor SQL Server para gestionar datos de estudiantes y horarios.
<br> <!-- Salto de línea -->

## Tabla de Contenidos

- [Requisitos](#requisitos)
- [Publicar](#Publicar)
- [Instalación](#instalación)
- [Endpoints](#Endpoints)

<br> <!-- Este es un salto de línea -->

## Requisitos
Asegúrate de tener instaladas las siguientes tecnologías antes de comenzar:
- .NET 6.0
- SQL Server

<br> <!-- Este es un salto de línea -->

## Publicar
### Configuración para Publicar en Servidor FTP
Para llevar a cabo la publicación de la API en el servidor FTP, se necesitan los siguientes detalles de configuración:

- Servidor 
- Ruta de acceso al sitio
- Direccion URL de destino
- Nombre usuario
- Contraseña

### Servidor FTP
Proporcione la dirección IP o el nombre de dominio del servidor FTP al que se conectará para subir los archivos.

### Ruta de Acceso al Sitio
Indique la ruta específica en el servidor FTP donde desea alojar la aplicación. Puede ser un directorio específico, como "/httpdocs".

### Dirección URL de Destino:
Proporcione la URL completa de la aplicación después de ser desplegada. Ejemplo: "http://www.ejemplo.com/api".

### Nombre de Usuario
Proporcione el nombre de usuario que se utilizará para autenticarse en el servidor FTP y cargar los archivos.

### Contraseña
Proporcione la contraseña correspondiente al nombre de usuario para la autenticación en el servidor FTP.

<br> <!-- Este es un salto de línea -->

## Instalación

1. Clona este repositorio en tu máquina local:
```bash
git clone https://github.com/Alexis-Chavarria/API_Git-Practice.git
```
2. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio).
3. Ejecuta la aplicación.
```bash
dotnet run
```
La API estará disponible en https://localhost:7000/api/schedule

<br> <!-- Este es un salto de línea -->

## Endpoints

### Validar Estudiante Activo
- Endpoint: /api/schedule/query
- Método HTTP: POST
- Descripción: Endpoint para validar si un estudiante está activo.
- Cuerpo de la Solicitud: 
```bash
{
    "NUM_IDENTIFICACION" : "1045702044"
}
```

### Validar Estudiante Activo
- Endpoint: /api/schedule/generate-pdf
- Método HTTP: POST
- Descripción: Endpoint para generar el PDF del horario del estudiante en formato BASE64.
- Cuerpo de la Solicitud: 
```bash
{
    "NUM_IDENTIFICACION" : "1045702044"
}
```





