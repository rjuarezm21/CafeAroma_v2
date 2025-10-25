namespace CafeAroma_v2.Clases.Factory
{
    public class FabricaDeCombos
    {
        public (ProductoCafe cafe, string taza, string filtro) CrearCombo(string tipoCafe)
        {
            var cafe = ProductoFactory.CrearCafe(tipoCafe);
            return (cafe, "Taza Café Aroma", "Filtro Premium");
        }
    }
}
