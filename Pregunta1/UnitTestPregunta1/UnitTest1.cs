using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pregunta1Api.Controllers;
using Pregunta1Api.Models;

namespace UnitTestPregunta1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange
            OsinagasController osinagasController = new OsinagasController();

            //Act
            var Resultado = osinagasController.GetOsinagas();

            //Assert
            Assert.IsNotNull(Resultado);
        }

        [TestMethod]
        public void TestMethodPost()
        {
            //Arrange
            OsinagasController osinagasController = new OsinagasController();
            Osinaga Esperado = new Osinaga()
            {
                OsinagaID = 1,
                FriendofOsinaga = "Rafa Nadal",
                Place = PlaceType.Centro,
                Email = "rafa@hotmail.com",
                Birthday = DateTime.Today
            };

            //Act
            var Resultado = osinagasController.PostOsinaga(Esperado);
            var creado = Resultado as CreatedAtRouteNegotiatedContentResult<Osinaga>;

            //Assert
            Assert.IsNotNull(creado);
            Assert.AreEqual("DefaultApi", creado.RouteName);
            Assert.AreEqual(Esperado.FriendofOsinaga, creado.Content.FriendofOsinaga);
        }

        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange
            OsinagasController osinagasController = new OsinagasController();
            Osinaga osinaga = new Osinaga()
            {
                OsinagaID = 2,
                FriendofOsinaga = "Roger",
                Place = PlaceType.Urubo,
                Email = "roger@hotmail.com",
                Birthday = DateTime.Today
            };

            //Act
            IHttpActionResult actionResultPost = osinagasController.PostOsinaga(osinaga);
            var result = osinagasController.PutOsinaga(osinaga.OsinagaID, osinaga) as StatusCodeResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange
            OsinagasController osinagasController = new OsinagasController();
            Osinaga osinaga = new Osinaga()
            {
                OsinagaID = 3,
                FriendofOsinaga = "Nole",
                Place = PlaceType.ZonaNorte,
                Email = "nole@hotmail.com",
                Birthday = DateTime.Today
            };

            //Act
            IHttpActionResult actionResultPost = osinagasController.PostOsinaga(osinaga);
            IHttpActionResult actionResultDelete = osinagasController.DeleteOsinaga(osinaga.OsinagaID);

            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Osinaga>));
        }
    }
}
