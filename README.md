# API_VozyChatOps

API_VozyChatOps es una API desarrollada en ASP.NET que proporciona un servicio POST especializado para generar PDFs en formato BASE64, representando el horario de estudiantes, el cual puede ser consultado y enviado a través de un bot externo directamente a WhatsApp. Este proyecto está diseñado para integrarse sin problemas con sistemas de automatización de mensajería, ofreciendo una solución eficiente y segura para la distribución de horarios estudiantiles.
<br> <!-- Salto de línea -->

## Funcionalidades Principales
- Generación de PDF en BASE64: La API permite convertir los horarios de los estudiantes en un formato PDF codificado en BASE64, utilizando la librería QuestPDF, lo que facilita su transmisión y visualización a través de plataformas de mensajería como WhatsApp.
- Consulta de Estudiantes Activos: Realiza consultas a una base de datos SQL Server utilizando ADO.NET para verificar la actividad de los estudiantes en el periodo académico actual.
- Seguridad: Incluye un sistema de autenticación básico que genera un JWT válido por 24 horas, utilizando claims para asegurar que solo usuarios autenticados puedan acceder a los servicios.
- Integración con Servicios Externos: Consume un servicio externo para restablecer las contraseñas de los correos institucionales de los estudiantes, integrándose así con la infraestructura IT existente.
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





