﻿using MySql.Data.MySqlClient;
using SaberesySoluciones.Models;
using SaberesySoluciones.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaberesySoluciones.Repositories
{
    public class Competencias
    {
        public static Competencia Crear(Competencia competencia)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_crear", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_descripcion", Direction = System.Data.ParameterDirection.Input, Value = competencia.Descripcion });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_nivel_dominio", Direction = System.Data.ParameterDirection.Input, Value = competencia.Nivel });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_basico", Direction = System.Data.ParameterDirection.Input, Value = competencia.Basico });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_intermedio", Direction = System.Data.ParameterDirection.Input, Value = competencia.Intermedio });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_avanzado", Direction = System.Data.ParameterDirection.Input, Value = competencia.Avanzado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_tiempoDesarrollo", Direction = System.Data.ParameterDirection.Input, Value = competencia.TiempoDesarrollo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = competencia.Estado });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "out_codigo", Direction = System.Data.ParameterDirection.Output, Value = -1 });
                var datos = DataSource.ExecuteProcedure(command);

                competencia.Codigo = Convert.ToInt32(datos.Parameters["out_id"].Value);
                return competencia;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public static bool Deshabilitar(int codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value =  codigo});
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value =  "Deshabilitado" });
                var datos = DataSource.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        public static bool Habilitar(int codigo)
        {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_habilitar_deshabilitar", CommandType = System.Data.CommandType.StoredProcedure };
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_codigo", Direction = System.Data.ParameterDirection.Input, Value = codigo });
                command.Parameters.Add(new MySqlParameter() { ParameterName = "in_estado", Direction = System.Data.ParameterDirection.Input, Value = "Habilitado" });
                var datos = DataSource.ExecuteProcedure(command);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        public static bool Editar(Competencia competencia)
        {
            Boolean estadoConsulta;

            try
            {
                competencia = Crear(competencia);
                if (competencia.Codigo != (-1))
                {
                    estadoConsulta = Deshabilitar(competencia.Codigo);
                    if (estadoConsulta == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

            }
        }

        public static List<Competencia> LeerTodo() {
            try
            {
                var command = new MySqlCommand() { CommandText = "sp_competencias_leertodo", CommandType = System.Data.CommandType.StoredProcedure };
                var datos = DataSource.GetDataSet(command);

                List<Competencia> comps = new List<Competencia>();
                if (datos.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in datos.Tables[0].Rows)
                    {
                        var prodData = row;
                        var comp = new Competencia()
                        {
                            Codigo = Convert.ToInt32(prodData["codigo"]),
                            Descripcion = prodData["descripcion"].ToString(),
                            Nivel = prodData["nivel_dominio"].ToString(),
                            Basico = prodData["basico"].ToString(),
                            Intermedio = prodData["intermedio"].ToString(),
                            Avanzado = prodData["avanzado"].ToString(),
                            TiempoDesarrollo = prodData["tiempoDesarrollo"].ToString(),
                            Estado = prodData["estado"].ToString()
                        };
                        comps.Add(comp);
                    }
                }
                return comps;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {

            }
            return null;

        }

    }
}