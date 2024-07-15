
namespace PersonaTest
{
    [TestClass]
    public class UnitTest1
    {
        //Instancio la clase Persona
        private Persona persona;
        // Inicializo la clase Persona
        [TestInitialize]
        public void Inicializar()
        {
            persona = new Persona();
        }
        // Prueba de la propiedad Nombre le paso datos al método
        // le paso varios datos al test
        [DataRow("JOSE ANTONIO", "Jose Antonio ")]
        [DataRow("mariA jiMenez garcia", "Maria Jimenez Garcia ")]
        [TestMethod]
        public void FormatoNombreTest(string nombre, string esperado)
        {
            // Act
            persona.Nombre = nombre;
            // Assert
            Assert.AreEqual(esperado, persona.Nombre);

        }
    }
}