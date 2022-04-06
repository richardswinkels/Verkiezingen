<!DOCTYPE html>
<?php
include_once "./classes/VerkiezingenDB.php";
$db = new VerkiezingenDB();
?>
<html lang="nl">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Verkiezingen</title>
    <link rel="stylesheet" href="css/styles.css" />
    <script src="./js/main.js"></script>
</head>

<body>
    <?php include "header.php"; ?>
    <main>
        <h1>Verkiezingsoverzicht</h1>
        <p>Selecteer een verkiezing uit de lijst om alle deelnemende partijen van de desbetreffende verkiezing in te zien.</p>
        <ul id="ul-verkiezingen">
            <?php
            //Vraag alle verkiezingen op
            $verkiezingen = $db->selectVerkiezingen();

            //Loop door de verkiezingen
            foreach ($verkiezingen as $verkiezing) {
                //Zet datum uit DB om naar timestamp
                $time = strtotime($verkiezing['Datum']);

                //Zet timestamp om naar nieuw datumformaat
                $date = date('d-m-Y', $time);
                
                //Maak voor elke verkiezing een item in de lijst
                echo "<li><a href='deelnemendepartijen.php?verkiezingid=$verkiezing[VerkiezingId]'><h2>$verkiezing[Verkiezingsoort]</h2></a><p>Deze verkiezing vindt plaats op {$date}.</p></li>";
            }
            ?>
        </ul>
    </main>
    <?php include "footer.php"; ?>
</body>

</html>