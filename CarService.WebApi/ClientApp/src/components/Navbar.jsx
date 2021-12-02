import { AppBar, Drawer, Toolbar, IconButton, Typography, Button, Divider } from "@mui/material";
import { useContext, useState } from "react";
import MenuIcon from '@mui/icons-material/Menu';
import { Box } from "@mui/system";
import LayoutContext from "./LayoutContext";
import { Link } from "react-router-dom";
const Navbar = (props) => {
    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);

    const styles = { paddingLeft: navOpen ? "200px" : "5px" }
    return <div>
        <AppBar position="static" open={navOpen} sx={styles}>
            <Toolbar>
                <IconButton
                    color="primary"
                    aria-label="open drawer"
                    onClick={() => { setNavOpen(!navOpen) }}
                    edge="start"

                >
                    <MenuIcon />
                </IconButton>
                <Typography color="primary" variant="h6" noWrap component="div">
                    {siteName}
                </Typography>
            </Toolbar>
        </AppBar>
        <Drawer open={navOpen} variant="persistent" anchor="left">
            <div style={{ width: "200px", height: "100%", display: "flex", paddingTop: "20px", justifyContent: "start", alignItems: "center", flexDirection: "column" }}>

                <Typography variant="h6" color="primary" fontWeight="bold">Materiály</Typography>
                <Button fullWidth LinkComponent={Link} to="/allmaterials">Všechny</Button>
                <Button fullWidth LinkComponent={Link} to="/">Analýza</Button>
                <Typography variant="h6" color="primary" fontWeight="bold">Zaměstanci</Typography>
                <Button fullWidth>Všechny</Button>
                <Button fullWidth>Analýza</Button>
            </div>
        </Drawer >

    </div >
}

export default Navbar;