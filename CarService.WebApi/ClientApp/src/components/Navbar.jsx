import { AppBar, Drawer, Toolbar, IconButton, Typography } from "@mui/material";
import { useState } from "react";
import MenuIcon from '@mui/icons-material/Menu';
import { Box } from "@mui/system";
const Navbar = (props) => {
    const [open, handleOpen] = useState(true);
    const styles = { paddingLeft: open ? "200px" : "5px" }
    return <div>
        <AppBar position="fixed" open={open} sx={styles}>
            <Toolbar>
                <IconButton
                    color="primary"
                    aria-label="open drawer"
                    onClick={() => { handleOpen(!open) }}
                    edge="start"

                >
                    <MenuIcon />
                </IconButton>
                <Typography color="primary" variant="h6" noWrap component="div">
                    Car Servis Information System
                </Typography>
            </Toolbar>
        </AppBar>
        <Drawer open={open} variant="persistent" anchor="left">
            <div style={{ width: "200px", height: "100%" }}>

            </div>
        </Drawer>

    </div>
}

export default Navbar;