using _IGraficasIES;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Instancio la clase Persona
        Persona persona;
        [TestInitialize]
        // Inicializo la clase Persona
        public void Initialize()
        {
            persona = new Persona();
        }

        [TestMethod]
        [DataRow("JOSE ANTONIO FERRE", "Jose Antonio Ferre")]
        [DataRow("jose antonio ferre", "Jose Antonio Ferre")]
        [DataRow("jose antOnio ferre", "Jose Antonio Ferre")]
        public void SepararWordsYFormatTest(string nombre, string esperado)
        {
            // Act
            persona.Nombre = nombre;
            // Assert
            Assert.AreEqual(esperado, persona.Nombre);
        }
    }
}