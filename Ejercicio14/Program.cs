/* 
Escriba un programa que cargue una lista de palabras desde un archivo de texto (que contendrá una palabra por línea), 
muestre en pantalla la cantidad de palabras leídas
Ordene las palabras alfabéticamente, y reescriba el archivo original con la lista ordenada.
 */

List<string> ListaPalabras = File.ReadAllText("palabras.txt").Split('\n').ToList();
Console.WriteLine($"El archivo tiene {ListaPalabras.Count} palabras");
ListaPalabras.Sort();
File.WriteAllLines("palabras.txt", ListaPalabras);