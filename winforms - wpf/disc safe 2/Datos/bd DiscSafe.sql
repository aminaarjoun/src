--disc safe 2, base de datos

create table disco(
	iddisco INTEGER primary key autoincrement,
	nombre TEXT not null,
	categoria TEXT
);


create table directorio(
	iddir INTEGER primary key autoincrement,
	nombre TEXT not null,
	dirpadre INTEGER, 
	iddisco INTEGER
		CONSTRAINT fk_iddisco REFERENCES disco(iddisco) ON DELETE CASCADE
);

create table archivo(
	idarch INTEGER PRIMARY KEY autoincrement,
	nombre TEXT,
	extension TEXT,
	tambytes INTEGER unsigned,
	fechamod datetime,
	iddir INTEGER
		CONSTRAINT fk_iddir REFERENCES directorio(iddir) ON DELETE CASCADE
);


--para que los FK funcionen posta...


-- Foreign Key Preventing insert
CREATE TRIGGER fki_directorio_iddisco_disco_iddisco
BEFORE INSERT ON [directorio]
FOR EACH ROW BEGIN
  SELECT RAISE(ROLLBACK, 'insert on table "directorio" violates foreign key constraint "fki_directorio_iddisco_disco_iddisco"')
  WHERE NEW.iddisco IS NOT NULL AND (SELECT iddisco FROM disco WHERE iddisco = NEW.iddisco) IS NULL;
END;

-- Foreign key preventing update
CREATE TRIGGER fku_directorio_iddisco_disco_iddisco
BEFORE UPDATE ON [directorio]
FOR EACH ROW BEGIN
    SELECT RAISE(ROLLBACK, 'update on table "directorio" violates foreign key constraint "fku_directorio_iddisco_disco_iddisco"')
      WHERE NEW.iddisco IS NOT NULL AND (SELECT iddisco FROM disco WHERE iddisco = NEW.iddisco) IS NULL;
END;

-- Cascading Delete
CREATE TRIGGER fkdc_directorio_iddisco_disco_iddisco
BEFORE DELETE ON disco
FOR EACH ROW BEGIN
    DELETE FROM directorio WHERE directorio.iddisco = OLD.iddisco;
END;

-- Foreign Key Preventing insert
CREATE TRIGGER fki_directorio_iddisco_disco_iddisco
BEFORE INSERT ON [directorio]
FOR EACH ROW BEGIN
  SELECT RAISE(ROLLBACK, 'insert on table "directorio" violates foreign key constraint "fki_directorio_iddisco_disco_iddisco"')
  WHERE NEW.iddisco IS NOT NULL AND (SELECT iddisco FROM disco WHERE iddisco = NEW.iddisco) IS NULL;
END;

-- Foreign key preventing update
CREATE TRIGGER fku_directorio_iddisco_disco_iddisco
BEFORE UPDATE ON [directorio]
FOR EACH ROW BEGIN
    SELECT RAISE(ROLLBACK, 'update on table "directorio" violates foreign key constraint "fku_directorio_iddisco_disco_iddisco"')
      WHERE NEW.iddisco IS NOT NULL AND (SELECT iddisco FROM disco WHERE iddisco = NEW.iddisco) IS NULL;
END;

-- Cascading Delete
CREATE TRIGGER fkdc_directorio_iddisco_disco_iddisco
BEFORE DELETE ON disco
FOR EACH ROW BEGIN
    DELETE FROM directorio WHERE directorio.iddisco = OLD.iddisco;
END;

-- Foreign Key Preventing insert
CREATE TRIGGER fki_archivo_iddir_directorio_iddir
BEFORE INSERT ON [archivo]
FOR EACH ROW BEGIN
  SELECT RAISE(ROLLBACK, 'insert on table "archivo" violates foreign key constraint "fki_archivo_iddir_directorio_iddir"')
  WHERE NEW.iddir IS NOT NULL AND (SELECT iddir FROM directorio WHERE iddir = NEW.iddir) IS NULL;
END;

-- Foreign key preventing update
CREATE TRIGGER fku_archivo_iddir_directorio_iddir
BEFORE UPDATE ON [archivo]
FOR EACH ROW BEGIN
    SELECT RAISE(ROLLBACK, 'update on table "archivo" violates foreign key constraint "fku_archivo_iddir_directorio_iddir"')
      WHERE NEW.iddir IS NOT NULL AND (SELECT iddir FROM directorio WHERE iddir = NEW.iddir) IS NULL;
END;

-- Cascading Delete
CREATE TRIGGER fkdc_archivo_iddir_directorio_iddir
BEFORE DELETE ON directorio
FOR EACH ROW BEGIN
    DELETE FROM archivo WHERE archivo.iddir = OLD.iddir;
END;








--deberia restringir que exista el dir padre cuando es diferente de NULL
--para ver las tablas...	
	SELECT name FROM 
   (SELECT * FROM sqlite_master UNION ALL
    SELECT * FROM sqlite_temp_master)
WHERE type='table'
ORDER BY name;


