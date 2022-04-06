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
        <h1>Contactgegevens</h1>
        <?php
        //Als partijid gezet is
        if (isset($_GET['partijid'])) {
            //Als selectContactgegevens gegevens terugkrijgt
            if ($contactgegevens = $db->selectContactgegevens($_GET['partijid'])) {
                //Laat tabel zien
                echo "<table>
                <tr>
                    <th colspan='2'>$contactgegevens[PartijName]</th>
                </tr>
                <tr>
                    <th>Adres</th>
                    <td>$contactgegevens[Adres]</td>
                </tr>
                <tr>
                    <th>Postcode</th>
                    <td>$contactgegevens[Postcode]</td>
                </tr>
                <tr>
                    <th>Gemeente</th>
                    <td>$contactgegevens[Gemeente]</td>
                </tr>
                <tr>
                    <th>E-mailadres</th>
                    <td>$contactgegevens[EmailAdres]</td>
                </tr>
                <tr>
                    <th>Telefoonnummer</th>
                    <td>$contactgegevens[Telefoonnummer]</td>
                </tr>
                <tr>
                    <td colspan='2'><button onclick='goBackPage()'>Ga terug naar vorige pagina.</button></td>
                </tr>
                </table>";
            } 
            //Anders (als er geen gegevens zijn)
            else {
                //Laat foutmelding zien
                echo "<p>Opgevraagde partij niet gevonden!</p>";
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