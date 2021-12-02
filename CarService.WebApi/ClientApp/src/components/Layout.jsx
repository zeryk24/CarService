
import { useState } from "react";
import Navbar from "./Navbar"
import LayoutContext from "./LayoutContext";
const Layout = (props) => {
    const [navOpen, setNavOpen] = useState(false);
    const [siteName, setSiteName] = useState("Car Servis Information System");
    return <div style={{ height: "100%" }}>
        <LayoutContext.Provider value={{ navOpen, setNavOpen, siteName, setSiteName }}>
            <Navbar />
            {props.children}
        </LayoutContext.Provider>
    </div >
}

export default Layout;