using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using pract3.model;

namespace pract3
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(Description = "Consulta de libros")]
        public List<libro> ObtenerLibro()
        {
            using (masterEntities conexion = new masterEntities())
            {
                //select * from Libros;
                //List<Libro> consulta = from c in conexion.Libros select c;
                var consulta = from c in conexion.libros select c;
                return consulta.ToList();
            }
        }
        [WebMethod(Description = "Agregar libro")]
        public bool InsertarLibro(int id, String titulo, string autor, string precio, string añopublicacion)
        {
            using (masterEntities conexion = new masterEntities())
            {
                libro nuevo = new libro();
                nuevo.id = id;
                nuevo.titulo = titulo;
                nuevo.autor = autor;
                nuevo.precio = precio;
                nuevo.añopublicacion = añopublicacion;
                conexion.libros.Add(nuevo);
                conexion.SaveChanges();
                return true;
            }
        }
        [WebMethod(Description = "Eliminar libro")]
        public bool EliminarLibro(int id)
        {
            using (masterEntities conexion = new masterEntities())
            {
                var libro = (from c in conexion.libros where c.id == id select c).FirstOrDefault();
                if (libro != null)
                {
                    conexion.libros.Remove(libro);
                    conexion.SaveChanges();
                }
                return true;
            }
        }
        [WebMethod(Description = "Editar libro")]
        public bool EditarLibro(int id, String titulo, string autor, string precio, string añopublicacion)
        {
            using (masterEntities conexion = new masterEntities())
            {
                var libro = (from c in conexion.libros where c.id == id select c).FirstOrDefault();
                if (libro != null)
                {
                    libro.id = id;
                    libro.titulo = titulo;
                    libro.autor = autor;
                    libro.precio = precio;
                    libro.añopublicacion = añopublicacion;
                    conexion.SaveChanges();
                }
                return true;
            }
        }
    }
}

