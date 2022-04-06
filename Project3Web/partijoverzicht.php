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
        <h1>Partijoverzicht</h1>
        <p>Selecteer een partij om daarvan de contactgegevens in te zien.</p>
        <?php 
            //Vraag alle partijen op
            $partijen = $db->selectPartijen();
        ?>
        <div class="grid-partijen">
            <?php
                //Loop door de partijen
                foreach($partijen as $partij) {
                    //Maak voor elke partij een nieuwe item in de grid
                    echo "<a href='contactgegevens.php?partijid=$partij[PartijId]'><div class='item-partijen'><p>$partij[PartijName]</p></div></a>";
                }
            ?>
        </div>
    </main>
    <?php include "footer.php"; ?>
</body>
</html>