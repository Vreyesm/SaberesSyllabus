DELIMITER $$
DROP PROCEDURE IF EXISTS sp_competencias_crear $$
CREATE PROCEDURE sp_competencias_crear
(
	in_descripcion VARCHAR(256),
  	in_nivel_dominio VARCHAR(256),
  	in_basico TEXT,
  	in_intermedio TEXT,
  	in_avanzado TEXT,
  	in_tiempoDesarrollo VARCHAR(256),
  	in_estado VARCHAR(256),
	OUT out_codigo INTEGER
)
BEGIN

	INSERT INTO competencia(descripcion, nivel_dominio, basico, intermedio, avanzado, tiempoDesarollo, estado)
	VALUES (in_descripcion, in_nivel_dominio, in_basico, in_intermedio, in_avanzado, in_tiempoDesarrollo, in_estado);

	SET out_codigo = LAST_INSERT_ID();
END
$$
