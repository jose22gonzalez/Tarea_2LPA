using System.Collections.Generic;
using System.Linq;

using System.Linq.Expressions;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System;


namespace TareaPA_1
{
    public class RolesBBL{
        
        public static bool Insertar(Roles roles){
            bool paso = false;
            
            
            using(var contexto = new Contexto()){
            contexto.Roles.Add(roles);
            paso = contexto.SaveChanges() > 0;
            }
            
            return paso;
        }

        public static List<Roles> GetLista(){
            using(var contexto = new Contexto()){
                return contexto.Roles.ToList();
            }
        }

        public static bool Modificar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            
            try
            {
                
                contexto.Entry(roles).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

          public static bool Eliminar(String rolid)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var roles = contexto.Roles.Find(rolid);
                if (roles != null)
                {
                    contexto.Roles.Remove(roles); //remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

         public static bool Existe(string descripcion)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static Roles Buscar(string rolesID)
        {
            Contexto contexto = new Contexto();
            Roles rol;

            try{
                rol = contexto.Roles.Find(rolesID);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return rol;
        }



    }
}
