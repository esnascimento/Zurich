CREATE OR REPLACE PACKAGE ExameZurichPk AS

-- $Header: ExameZurichPk.pls                16/02/2020 ExameZurichPk$
-- +=================================================================+
-- |                    IT Zurich, Sao Paulo, Brasil                 |
-- |                       All rights reserved.                      |
-- +=================================================================+
-- | FILENAME                                                        |
-- |   ExameZurichPk.pls                                             |
-- | PURPOSE                                                         |
-- |  Gerenciar processos de Seguro Automotivo                       |
-- |                                                                 |
-- |                                                                 |
-- | DESCRIPTION                                                     |
-- |  Gerenciar processos de Seguro Automotivo                       |
-- |                                                                 |
-- | CREATED BY   esnascimento    - 16/02/2020                       |
-- |     Edson da Silva Nascimento - 16/02/2020 - 001                |
-- | UPDATED BY                                                      |
-- |                                                                 |
-- |                                                                 |
-- +=================================================================+
   /*================================================================+
  | Procedimento de Inclusão do Seguro na Base                       |
  |                                                                  |
  | Autor: Edson da Silva Nascimento                                 |
  | CREATED BY: 16/02/2020                                           |
  +=================================================================*/
   PROCEDURE IncluirSeguro ( pFIRSTNAME IN VARCHAR2
                           , pLASTNAME  IN VARCHAR2
                           , pDOCUMENT  IN VARCHAR2
                           , pDOCUMENTTYPE  IN VARCHAR2
                           , pAge           IN NUMBER
                           , pMARCA         IN VARCHAR2
                           , pMODELO        IN VARCHAR2
                           , pVALOR         IN NUMBER
                           , pLUCRO         IN NUMBER
                           , pTAXRC         IN NUMBER
                           , pMARGEMSEG     IN NUMBER
                           , pPREMIORC      IN NUMBER
                           , pPREMIOPR      IN NUMBER
                           , pPREMIOCM      IN NUMBER
                           , pSaida OUT VARCHAR2);
   /*================================================================+
  | Procedimento de Consulta de Seguro para CPF especifico           |
  |                                                                  |
  | Autor: Edson da Silva Nascimento                                 |
  | CREATED BY: 16/02/2020                                           |
  +=================================================================*/                     
  PROCEDURE ConsultarSeguro (pDocument IN VARCHAR2, pCursor OUT SYS_REFCURSOR);
END;
/
CREATE OR REPLACE PACKAGE BODY ExameZurichPk AS 
PROCEDURE IncluirSeguro ( pFIRSTNAME IN VARCHAR2
                         , pLASTNAME  IN VARCHAR2
                         , pDOCUMENT  IN VARCHAR2
                         , pDOCUMENTTYPE  IN VARCHAR2
                         , pAge           IN NUMBER
                         , pMARCA         IN VARCHAR2
                         , pMODELO        IN VARCHAR2
                         , pVALOR         IN NUMBER
                         , pLUCRO         IN NUMBER
                         , pTAXRC         IN NUMBER
                         , pMARGEMSEG     IN NUMBER
                         , pPREMIORC      IN NUMBER
                         , pPREMIOPR      IN NUMBER
                         , pPREMIOCM      IN NUMBER
                         , pSaida OUT VARCHAR2) 
IS
  vCodSsegurado NUMBER := 0;
  vCodVeiculo NUMBER := 0;
  vCodSeguro NUMBER := 0;
  vFlaError boolean :=false;
BEGIN
     BEGIN
        SELECT ZURICH.SEGURADOSEQ.NEXTVAL INTO vCodSsegurado FROM DUAL;
     EXCEPTION
       WHEN OTHERS THEN
          vFlaError := true;
          pSaida := ('Erro no ZURICH.SEGURADOSEQ. ERRO: '||SQLERRM);
     END;
     IF vFlaError = false THEN
        BEGIN
             INSERT INTO ZURICH.SEGURADO ( CODSEGURADO --> 1
                                  , FIRSTNAME   --> 2
                                  , LASTNAME    --> 3
                                  , DOCUMENT    --> 4
                                  , DOCUMENTTYPE --> 5
                                  , LAST_UPDATE_DATE --> 6
                                  , LAST_UPDATED_BY  --> 7
                                  , CREATION_DATE    --> 8
                                  , CREATED_BY       --> 9
                                  , ACTIVE           --> 10
                                  , AGE              --> 11
                                 )
                           VALUES( vCodSsegurado --> 1
                                 , pFIRSTNAME    --> 2
                                 , pLASTNAME     --> 3
                                 , pDOCUMENT     --> 4
                                 , pDOCUMENTTYPE --> 5
                                 , SYSDATE       --> 6
                                 , 1             --> 7
                                 , SYSDATE       --> 8
                                 , 1             --> 9
                                 , 'Y'           --> 10
                                 , pAge          --> 11
                                  );
        EXCEPTION
           WHEN OTHERS THEN
                vFlaError := true;
              pSaida := ('Erro no ZURICH.SEGURADO. ERRO: '||SQLERRM);
         END;
     END IF;
      IF vFlaError = false THEN
         BEGIN
            SELECT ZURICH.VEICULOSEQ.NEXTVAL INTO vCodVeiculo FROM DUAL;
         EXCEPTION
           WHEN OTHERS THEN
              vFlaError := true;
              pSaida := ('Erro no ZURICH.VEICULOSEQ. ERRO: '||SQLERRM);
         END;
         IF vFlaError = false THEN
           BEGIN
           INSERT INTO ZURICH.VEICULO ( CODVEICULO --> 1
                                      , MARCA   --> 2
                                      , MODELO    --> 3
                                      , LAST_UPDATE_DATE --> 4
                                      , LAST_UPDATED_BY  --> 5
                                      , CREATION_DATE    --> 6
                                      , CREATED_BY       --> 7
                                      , ACTIVE           --> 8
                                     )
                               VALUES( vCodVeiculo --> 1
                                     , pMARCA        --> 2
                                     , pMODELO          --> 3
                                     , SYSDATE       --> 4
                                     , 1             --> 5
                                     , SYSDATE       --> 6
                                     , 1             --> 7
                                     , 'Y'           --> 8
                                      );
              EXCEPTION
                 WHEN OTHERS THEN
                      vFlaError := true;
                    pSaida := ('Erro no ZURICH.VEICULO. ERRO: '||SQLERRM);
               END;
           END IF;
        END IF;
        IF vFlaError = false THEN
             BEGIN
                SELECT ZURICH.SEGUROSEQ.NEXTVAL INTO vCodSeguro FROM DUAL;
             EXCEPTION
               WHEN OTHERS THEN
                  vFlaError := true;
                  pSaida := ('Erro no ZURICH.SEGUROSEQ. ERRO: '||SQLERRM);
             END;
             IF vFlaError = false THEN
               BEGIN
               INSERT INTO ZURICH.SEGURO ( CODSEGURO         --> 1
                                          , DESCRIPTION      --> 2
                                          , LAST_UPDATE_DATE --> 3
                                          , LAST_UPDATED_BY  --> 4
                                          , CREATION_DATE    --> 5
                                          , CREATED_BY       --> 6
                                          , ACTIVE           --> 7
                                          , CODVEICULO       --> 8
                                          , CODSEGURADO      --> 9
                                          , VALUE            --> 10
                                          , LUCRO_PC         --> 11
                                          , TAX_RC           --> 12
                                          , MARGEM_SG        --> 13
                                          , PREMIO_RC        --> 14
                                          , PREMIO_PR        --> 15
                                          , PREMIO_CM        --> 16 
                                         )
                                   VALUES( vCodSeguro --> 1
                                         , 'SEGURO - '||pFIRSTNAME||' '||pLASTNAME||'- DOC:'||pDOCUMENT||'- MARCA\MODELO:'||pMARCA||'\'||pMODELO --> 2
                                         , SYSDATE       --> 3
                                         , 1             --> 4
                                         , SYSDATE       --> 5
                                         , 1             --> 6
                                         , 'Y'           --> 7
                                         , vCodVeiculo   --> 8
                                         , vCodSsegurado --> 9
                                         , pVALOR        --> 10
                                         , pLUCRO        --> 11
                                         , pTAXRC        --> 12
                                         , pMARGEMSEG    --> 13
                                         , pPREMIORC     --> 14
                                         , pPREMIOPR     --> 15
                                         , pPREMIOCM     --> 16
                                          );
                EXCEPTION
                   WHEN OTHERS THEN
                      vFlaError := true;
                      pSaida := ('Erro no ZURICH.SEGURO. ERRO: '||SQLERRM);
                 END;
             END IF;
         END IF;
         IF vFlaError = false THEN
            COMMIT;
         ELSE
             ROLLBACK;
         END IF;
EXCEPTION
  WHEN OTHERS THEN
     pSaida := 'ROLLBACK';
      RAISE_APPLICATION_ERROR(-20001, 'Erro na ExameZurichPk. ERRO: '||SQLERRM);
END;

    PROCEDURE ConsultarSeguro (pDocument IN VARCHAR2, pCursor OUT SYS_REFCURSOR)
    IS
    BEGIN
      OPEN pCursor FOR
        SELECT SEGU.FIRSTNAME
             , SEGU.LASTNAME
             , SEGU.Document
             , SEGU.AGE
             , VEIC.MARCA
             , VEIC.Modelo
             , SEG.Value  
           FROM SEGURADO SEGU,
                VEICULO  VEIC,
                SEGURO   SEG
        WHERE SEG.CODSEGURADO = SEGU.CODSEGURADO
          AND SEG.Codveiculo  = VEIC.CODVEICULO
          AND SEGU.Document   = pDocument;
    EXCEPTION
      WHEN OTHERS THEN
        RAISE_APPLICATION_ERROR(-20002, 'Erro na ExameZurichPk.ConsultarSeguro ERRO: '||SQLERRM);
    END;

END;
/
