import { AppBar, Drawer, Toolbar, IconButton, Typography } from "@mui/material";
import { useContext, useState } from "react";
import MenuIcon from '@mui/icons-material/Menu';
import { Box } from "@mui/system";
import LayoutContext from "./LayoutContext";
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
            <div style={{ width: "200px", height: "100%" }}>

            </div>
        </Drawer>

    </div>
}

export default Navbar;