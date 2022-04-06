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
        <h1>Deelnemende partijen</h1>
        <?php
        //Als verkiezingid gezet is
        if (isset($_GET['verkiezingid'])) {
            //Als selectDeelnemendePartijen gegevens terugkrijgt
            if($partijen = $db->selectDeelnemendePartijen($_GET['verkiezingid'])) {
                //Vraag de gegevens van de bijbehorende verkiezing op
                $verkiezing = $db->selectVerkiezing($_GET['verkiezingid']);

                //Laat beschrijving zien met verkiezingsnaam
                echo "<p>Alle deelnemende partijen aan de " . strtolower($verkiezing['Verkiezingsoort']) . ".</p>";
                //Maak de grid
                echo "<div class='grid-partijen'>";
                //Loop door de partijen
                foreach ($partijen as $partij) {
                    //Maak voor elke partij een item in de grid
                    echo "<a href='contactgegevens.php?partijid=$partij[PartijId]'><div class='item-partijen'><p>$partij[PartijName]</p></div></a>";
                }
                //Sluit grid af
                echo "</div>";
            }
            //Anders (als er geen gegevens zijn)
            else {
                //Laat foutmelding zien
                echo "<p>Geen partijen gevonden voor de opgevraagde verkiezing!</p>";
            }
        }
        else {
            echo "<p>Opgevraagde pagina niet gevonden!</p>";
        }
        ?>
    </main>
    <?php include "footer.php"; ?>
</body>

</html>