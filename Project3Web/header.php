<?php $activePage = pathinfo($_SERVER['PHP_SELF'], PATHINFO_FILENAME); ?>
<header>
    <div id="banner">
    </div>
        <nav>
            <div class="nav-container">
                <ul class="menu">
                    <li <?php if ($activePage == "index") echo 'class="active"'; ?>><a href="index.php">Homepagina</a></li>
                    <li <?php if ($activePage == "verkiezingsoverzicht" || $activePage == "deelnemendepartijen") echo 'class="active"'; ?>><a href="verkiezingsoverzicht.php">Verkiezingen</a></li>
                    <li <?php if ($activePage == "partijoverzicht" || $activePage == "contactgegevens") echo 'class="active"'; ?>><a href="partijoverzicht.php">Contactgegevens</a></li>
                </ul>
                <div class="hamburger" onclick="toggleMenu()">
                    <div></div>
                    <div></div>
                    <div></div>
                </div>
            </div>
        </nav>
</header>