CREATE TABLE SEGURADO(
       CODSEGURADO NUMBER PRIMARY KEY
      , FIRSTNAME VARCHAR2(250) NOT NULL
      , LASTNAME VARCHAR2(500)
      , DOCUMENT VARCHAR2(14) NOT NULL
      , DOCUMENTTYPE VARCHAR2(4)NOT NULL
      , AGE          NUMBER NOT NULL
      , LAST_UPDATE_DATE DATE NOT NULL
      , LAST_UPDATED_BY  NUMBER(15) NOT NULL
      , CREATION_DATE    DATE NOT NULL
      , CREATED_BY       NUMBER(15) NOT NULL
      , ACTIVE           CHAR(1)
      , ATTRIBUTE1       VARCHAR2(150)
      , ATTRIBUTE2       VARCHAR2(150)
      , ATTRIBUTE3       VARCHAR2(150)
      , ATTRIBUTE4       VARCHAR2(150)
      , ATTRIBUTE5       VARCHAR2(150)
      , ATTRIBUTE6       VARCHAR2(150)
      , ATTRIBUTE7       VARCHAR2(150)
      , ATTRIBUTE8       VARCHAR2(150)
      , ATTRIBUTE9       VARCHAR2(150)
      , ATTRIBUTE10      VARCHAR2(150)
);

CREATE TABLE VEICULO(
       CODVEICULO  NUMBER PRIMARY KEY
      , MARCA VARCHAR2(250) NOT NULL
      , MODELO VARCHAR2(250) NOT NULL
      , LAST_UPDATE_DATE DATE NOT NULL
      , LAST_UPDATED_BY  NUMBER(15) NOT NULL
      , CREATION_DATE    DATE NOT NULL
      , CREATED_BY       NUMBER(15) NOT NULL
      , ACTIVE           CHAR(1)
      , ATTRIBUTE1       VARCHAR2(150)
      , ATTRIBUTE2       VARCHAR2(150)
      , ATTRIBUTE3       VARCHAR2(150)
      , ATTRIBUTE4       VARCHAR2(150)
      , ATTRIBUTE5       VARCHAR2(150)
      , ATTRIBUTE6       VARCHAR2(150)
      , ATTRIBUTE7       VARCHAR2(150)
      , ATTRIBUTE8       VARCHAR2(150)
      , ATTRIBUTE9       VARCHAR2(150)
      , ATTRIBUTE10      VARCHAR2(150)
);

CREATE TABLE SEGURO(
       CODSEGURO  NUMBER PRIMARY KEY
      , DESCRIPTION VARCHAR(2000)
      , LAST_UPDATE_DATE DATE NOT NULL
      , LAST_UPDATED_BY  NUMBER(15) NOT NULL
      , CREATION_DATE    DATE NOT NULL
      , CREATED_BY       NUMBER(15) NOT NULL
      , ACTIVE           CHAR(1)
      , VALUE            NUMBER(10,2)
      , LUCRO_PC         NUMBER(10,2)
      , MARGEM_SG        NUMBER(10,2)
      , TAX_RC           NUMBER(10,2)
      , PREMIO_RC        NUMBER(10,2)
      , PREMIO_PR        NUMBER(10,2)
      , PREMIO_CM        NUMBER(10,2)    
      , ATTRIBUTE1       VARCHAR2(150)
      , ATTRIBUTE2       VARCHAR2(150)
      , ATTRIBUTE3       VARCHAR2(150)
      , ATTRIBUTE4       VARCHAR2(150)
      , ATTRIBUTE5       VARCHAR2(150)
      , ATTRIBUTE6       VARCHAR2(150)
      , ATTRIBUTE7       VARCHAR2(150)
      , ATTRIBUTE8       VARCHAR2(150)
      , ATTRIBUTE9       VARCHAR2(150)
      , ATTRIBUTE10      VARCHAR2(150)
      , CODVEICULO       NUMBER
      , CODSEGURADO      NUMBER
      , CONSTRAINT fk_VEICULO FOREIGN KEY (CODVEICULO) REFERENCES VEICULO(CODVEICULO)
      , CONSTRAINT fk_SEGURADO FOREIGN KEY (CODSEGURADO) REFERENCES SEGURADO(CODSEGURADO)
);