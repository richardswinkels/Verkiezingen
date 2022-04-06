<?php
 class VerkiezingenDB {
    //Database adres en login credentials
    const DSN = "mysql:host=localhost;dbname=verkiezingenprj3;charset=utf8";
    const USER = "root";
    const PASSWD = ""; 

    //Selecteer alle verkiezingen
    function selectVerkiezingen() {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);

            //Maak nieuwe SQL query
            $statement = $pdo->prepare("SELECT * FROM verkiezing");

            //Voer statement uit
            $statement->execute();

            //Zorg dat data als associative array in $rows komt te staan
            $rows = $statement->fetchAll(PDO::FETCH_ASSOC);
            
            //Geef rows terug
            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    //Selecteer één bepaalde verkiezing
    function selectVerkiezing($verkiezingId) {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);

            //Maak nieuwe SQL query
            $statement = $pdo->prepare("SELECT * FROM verkiezing WHERE `verkiezing`.`VerkiezingId`= :verkiezingId");

            //Stel de parameters in
            $statement->bindValue(":verkiezingId", $verkiezingId, PDO::PARAM_INT);

            //Voer statement uit
            $statement->execute();

            //Zorg dat data als associative array in $rows komt te staan
            $rows = $statement->fetchAll(PDO::FETCH_ASSOC);

            //Geef eerste row terug
            return $rows[0];
        } catch (PDOException $e) {
            return false;
        }
    }

    //Selecteer alle deelnemende partijen van een bepaalde verkiezing
    function selectDeelnemendePartijen($verkiezingId) {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);

            //Maak nieuwe SQL query
            $statement = $pdo->prepare("SELECT verkiezingspartijen.PartijId, verkiezingspartijen.VerkiezingId, partij.PartijName FROM verkiezingspartijen INNER JOIN partij ON verkiezingspartijen.PartijId = partij.PartijId WHERE verkiezingspartijen.VerkiezingId = :verkiezingId");
            
            //Stel de parameters in
            $statement->bindValue(":verkiezingId", $verkiezingId, PDO::PARAM_INT);

            //Voer statement uit
            $statement->execute();

            //Zorg dat data als associative array in $rows komt te staan
            $rows = $statement->fetchAll(PDO::FETCH_ASSOC);

            //Geef rows terug
            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    //Selecteer alle partijen
    function selectPartijen() {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);

            //Maak nieuwe SQL query
            $statement = $pdo->prepare("SELECT * FROM partij");

            //Voer statement uit
            $statement->execute();

            //Zorg dat data als associative array in $rows komt te staan
            $rows = $statement->fetchAll(PDO::FETCH_ASSOC);

            //Geef rows terug
            return $rows;
        } catch (PDOException $e) {
            return false;
        }
    }

    //Selecteer contactgegevens van een bepaalde partij
    function selectContactgegevens($partijid) {
        try {
            $pdo = new PDO(self::DSN, self::USER, self::PASSWD);

            //Maak nieuwe SQL query
            $statement = $pdo->prepare("SELECT * FROM `partij` WHERE `partij`.`PartijId`= :partijId");

            //Stel de parameters in
            $statement->bindValue(":partijId", $partijid, PDO::PARAM_INT);

            //Voer statement uit
            $statement->execute();

            //Zorg dat data als associative array in $rows komt te staan
            $rows = $statement->fetchAll(PDO::FETCH_ASSOC);

            //Geef eerste row terug
            if(isset($rows[0])){
                return $rows[0];
            }   
        } catch (PDOException $e) {
            return false;
        }
    }
 }
