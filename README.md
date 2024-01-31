# API_VozyChatOps

Este API proporciona funcionalidades para validar la actividad de un estudiante y generar el horario en formato PDF. Utiliza tecnologías modernas como .NET 6.0 y se integra con un servidor SQL Server para gestionar datos de estudiantes y horarios.
<br> <!-- Salto de línea -->

## Tabla de Contenidos

- [Requisitos](#requisitos)
- [Instalación](#instalación)
- [Endpoints](#Endpoints)
- [Uso](#uso)
- [Ejemplos](#ejemplos)
- [Documentación](#documentación)
- [Contribución](#contribución)
- [Licencia](#licencia)

<br> <!-- Este es un salto de línea -->

## Requisitos
Asegúrate de tener instaladas las siguientes tecnologías antes de comenzar:
-.NET 6.0
-SQL Server

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
-Endpoint: /api/schedule/query
-Método HTTP: POST
-Descripción: Endpoint para validar si un estudiante está activo.
-Cuerpo de la Solicitud: 
```bash
{
    "NUM_IDENTIFICACION" : "1045702044"
}
```

### Validar Estudiante Activo
-Endpoint: /api/schedule/generate-pdf
-Método HTTP: POST
-Descripción: Endpoint para generar el PDF del horario del estudiante en formato BASE64.
-Cuerpo de la Solicitud: 
```bash
{
    "NUM_IDENTIFICACION" : "1045702044"
}
```





