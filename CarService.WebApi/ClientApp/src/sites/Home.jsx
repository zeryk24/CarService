import { Card, CardContent, Paper, Typography, Button } from "@mui/material";
import { useContext } from "react";
import LayoutContext from "../components/LayoutContext";

const MaterialCard = (props) => {
    let amount = props.amount;
    let positive = amount > 10;
    return <Card sx={{ width: "400px", margin: "10px" }}>
        <CardContent>
            <div style={{ width: "100%", display: "flex", justifyContent: "center", alignItems: "start" }}>
                <Typography sx={{ width: "80%" }} variant="h6" fontWeight="bold" color="primary"> {props.children} </Typography>
                <Typography sx={{ textAlign: "right", width: "20%" }} variant="h6" color={positive ? "lightgreen" : "lightsalmon"}> <b>{amount}&nbsp;Ks</b></Typography>
            </div>
            <div style={{ width: "100%", display: "flex", justifyContent: "center", alignItems: "center" }}>
                <Button sx={{ margin: "5px" }} variant="outlined">Objednat</Button>
                <Button sx={{ margin: "5px" }} variant="outlined">Zobrazit spotřebu</Button>
            </div>
        </CardContent>
    </Card >
}

const StatusCard = () => {
    return <Card sx={{ width: "100%", height: "100%", margin: "53px" }}>
        <CardContent>
            ffff
        </CardContent>
    </Card >
}
const Home = (props) => {
    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);
    setSiteName("Analýza spotřeby materiálů")
    return <div
        style={{
            paddingLeft: navOpen ? "250px" : "50px",
            paddingRight: "50px",
            paddingTop: "40px",
            display: "flex",
            justifyContent: "start",
            alignItems: "start",
            height: "100%",
            background: "#424242"
        }}>
        {/* Frequently used materials */}
        <div style={{ display: "flex", justifyContent: "center", alignItems: "center", flexDirection: "column" }}>
            <Typography color="primary" variant="h4">Často používané produkty</Typography>
            <MaterialCard amount={20}>Shell Helix HX7 5W-40 4L</MaterialCard>
            <MaterialCard amount={-5}>Clean Fox Zimní směs do ostřikovačů</MaterialCard>
            <MaterialCard amount={15}>STARLINE Antikorozní základ, sprej 400ml</MaterialCard>
            <MaterialCard amount={150}>WD-40 univerzální mazivo aerosol</MaterialCard>
            <Button sx={{ margin: "10px" }} variant="contained">Načíst více materiálů</Button>
        </div>
        <div style={{ display: "flex", flexGrow: "1" }}>
            <StatusCard />
        </div>
        {/* Missing materials */}
        <div style={{ display: "flex", justifyContent: "center", alignItems: "center", flexDirection: "column" }}>
            <Typography color="primary" variant="h4">Nejméně na skladě</Typography>
            <MaterialCard amount={-20}>Shell Helix HX7 5W-40 4L</MaterialCard>
            <MaterialCard amount={-5}>Clean Fox Zimní směs do ostřikovačů</MaterialCard>
            <MaterialCard amount={-1}>STARLINE Antikorozní základ, sprej 400ml</MaterialCard>
            <MaterialCard amount={20}>WD-40 univerzální mazivo aerosol</MaterialCard>
            <Button sx={{ margin: "10px" }} variant="contained">Načíst více materiálů</Button>
        </div>
    </div>
}

export default Home;