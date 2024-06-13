# OCR con Tesseract en C#

Este proyecto es un ejemplo de cómo utilizar Tesseract, un popular motor de OCR (reconocimiento óptico de caracteres), en una aplicación de C# para convertir imágenes a texto. Utilizamos el wrapper para .NET disponible en [este repositorio de Tesseract](https://github.com/charlesw/tesseract).

## Tabla de Contenidos

- [Instalación](#instalación)
- [Uso](#uso)
- [Configuración de Idiomas](#configuración-de-idiomas)

## Instalación

### Prerrequisitos

- .NET 6.0 o superior
- Visual Studio 2022 o superior

### Pasos de Instalación

1. Clona este repositorio en tu máquina local:

    ```sh
    git clone https://github.com/HeyJhon/ImageTorTextSharp.git
    cd ImageTorTextSharp
    ```

2. Abre el proyecto en Visual Studio.

3. Agrega la dependencia de Tesseract al proyecto usando NuGet Package Manager:

    ```sh
    Install-Package Tesseract
    ```

## Uso

### Ejemplo Básico

```csharp
using System;
using Tesseract;

namespace TuProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using var engine = new TesseractEngine(@"./tessdata", "spa", EngineMode.Default);
                using var img = Pix.LoadFromFile("ruta/a/tu/imagen.png");
                using var page = engine.Process(img);

                string texto = page.GetText();
                Console.WriteLine("Texto reconocido: \n" + texto);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
            }
        }
    }
}
```
## Configuración de Idiomas

Por defecto, el ejemplo utiliza el idioma español (`spa`). Puedes agregar más archivos de idioma siguiendo estos pasos:

1. Descarga los archivos de datos del idioma deseado desde el repositorio de Tesseract: [Tesseract Language Data](https://github.com/tesseract-ocr/tessdata).

2. Coloca los archivos descargados en la carpeta `tessdata` dentro de tu proyecto.

3. Cambia el código para utilizar el idioma que prefieras. Por ejemplo, para inglés, cambia `"spa"` a `"eng"`:

    ```csharp
    using var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
    ```
