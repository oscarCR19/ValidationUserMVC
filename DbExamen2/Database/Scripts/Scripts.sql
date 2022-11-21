CREATE DATABASE ExamenDB2;
USE ExamenDB2;


CREATE TABLE Users (
	Id Tinyint auto_increment NOT NULL,
    Name VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
	Password VARCHAR(256) NOT NULL,
    Photo VARCHAR(200) NULL,
    DateIn Datetime NOT NULL,
    primary key(Id)
) ;


Create table AuditPassword(
	id Tinyint NOT NULL,
    PrevPassw VARCHAR(256) NOT NULL,
    descrip VARCHAR(100) NOT NULL,
    dateModif Datetime NOT NULL
);

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spInsertUser`(IN pName VARCHAR(50), 
								 IN pEmail VARCHAR(100),
                                 IN pPassword VARCHAR(256),
                                 IN pPhoto VARCHAR(200),
                                 IN pDateIn Datetime)
BEGIN

	INSERT INTO users (Name, 
					   Email, 
                       Password,
                       Photo,
                       DateIn)
	VALUES (pName, 
			pEmail, 
			pPassword, 
            pPhoto,
            pDateIn);
END$$
DELIMITER ;



DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetEmail`(IN pEmail VARCHAR(100))
BEGIN
	SELECT * FROM Users WHERE Email = pEmail;
END$$

DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spValidateUser`(IN pEmail VARCHAR(100),IN pPassword VARCHAR(256))
BEGIN
	SELECT * FROM Users WHERE Email = pEmail and Password =pPassword;
END$$

DELIMITER ;

DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetUser`(IN pEmail VARCHAR(100))
BEGIN
	SELECT * FROM Users WHERE Email = pEmail;
END$$

DELIMITER ;

--trigger de insert Usuario
DELIMITER $$

CREATE TRIGGER trInsertUser
    AFTER INSERT
    ON Users FOR EACH ROW
BEGIN
    Insert Into AuditPassword(id,PrevPassw,descrip,dateModif) values(NEW.Id,NEW.Password,'Ingreso de usuario',current_timestamp());
END$$    

DELIMITER ;
--trigger cambio de comtraseña
DELIMITER $$

CREATE TRIGGER trUpdatePassword
    AFTER UPDATE
    ON Users FOR EACH ROW
BEGIN
    Insert Into AuditPassword(id,PrevPassw,descrip,dateModif) values(NEW.Id,NEW.Password,'Cambio de contraseña',current_timestamp());
END$$    

DELIMITER ;

--función para validar las 7 tiene cobtraseñas
DELIMITER //
CREATE FUNCTION fValidatePasswChang(Id INT,Password VARCHAR(256)) 
RETURNS INT 
  BEGIN
  DECLARE RespNum INT;
    DECLARE RespPassword VARCHAR(256);
    SET RespPassword =(select * from AuditPassword Ap inner join Users Us on
					Ap.id=Us.Id
 where PrevPassw=Password AND Us.Id=Id  order by dateModif desc limit 7);
    IF RespPassword IS NOT NULL THEN
    SET RespNum=1;
      RETURN RespNum;
    ELSE
    SET RespNum=0;
      RETURN RespNum;
    END IF;
  END //
DELIMITER //

--SP para validar la contraseña, adentro lleva la función anterior,devuelve un INT
DELIMITER $$  
CREATE DEFINER=`root`@`localhost` PROCEDURE `spValidatePasswChang`(IN pId INT,IN pPassword VARCHAR(256))
BEGIN
	select * from AuditPassword Ap inner join Users Us on
					Ap.id=Us.Id
 where PrevPassw=pPassword AND Us.Id=pId  order by dateModif desc limit 7;
END$$

DELIMITER ;

CREATE DEFINER=`root`@`localhost` PROCEDURE `spUpdatePassword`(IN pId INT,IN pPassword VARCHAR(256))
BEGIN
	update Users SET Password=pPassword where Id=pId;
END$$

DELIMITER ;



