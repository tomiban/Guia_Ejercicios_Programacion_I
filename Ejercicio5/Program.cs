static int PotenciaRecursiva(int baseNum, int exponente)
{
    // Si el exponente es 0, retorna 1, ya que 2^0 = 1
    if(exponente == 0)
        return 1;
    
    // Si no, retorna el resultado de multiplicar la base por su propia potencia,
    // pero reducida en 1 en el exponente.
    // Es decir, baseNum * PotenciaRecursiva(baseNum, exponente - 1)
    // Ejemplo: 2 * PotenciaRecursiva(2, 2 - 1) = 2 * PotenciaRecursiva(2, 1) = 2 * PotenciaRecursiva(2, 0) = 1
    return baseNum * PotenciaRecursiva(baseNum, exponente - 1);
}
Console.WriteLine(PotenciaRecursiva(2,3));