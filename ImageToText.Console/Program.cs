// See https://aka.ms/new-console-template for more information

using Tesseract;

string pathImage = @"C:\Utils\reymidasscan.jpg";
string pathData = @"C:\Utils\tessdata";
var engine = new TesseractEngine(pathData, "spa", EngineMode.Default);
var image = Pix.LoadFromFile(pathImage);
var page = engine.Process(image);

string text = page.GetText();
Console.WriteLine("El texto es:");
Console.WriteLine(text);