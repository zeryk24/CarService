import { Card, CardContent, Paper, Typography, Button, TextField, LinearProgress } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import ChartCard from "../components/ChartCard";
import LayoutContext from "../components/LayoutContext";
import MaterialsFasade from "../fasades/MaterialsFasade"
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


const Home = (props) => {
    const fasade = new MaterialsFasade();

    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);
    const [oftenMaterials, setOftenMaterials] = useState([]);
    const [leastMaterials, setLeastMaterials] = useState([]);
    useEffect(() => {
        setSiteName("Analýza spotřeby materiálů")
        fasade.GetAll().then((data) => {
            data = data.sort((a, b) => {
                return a.consumes.length > b.consumes.length ? 1 : -1;
            });
            setOftenMaterials(data);
            data = [...data];
            data = data.sort((a, b) => {
                return a.stockQuantity > b.stockQuantity ? 1 : -1;
            });
            setLeastMaterials(data);

        })
    }, []);
    if (oftenMaterials.length == 0) {
        return <LinearProgress />
    }

    let often_material_cards = [];
    let k = 0;
    for (let mat of oftenMaterials) {
        often_material_cards.push(<MaterialCard key={k++} amount={mat.stockQuantity}>{mat.name}</MaterialCard>)
    }
    let least_material_cards = [];
    k = 0;
    for (let mat of leastMaterials) {
        least_material_cards.push(<MaterialCard key={k++} amount={mat.stockQuantity}>{mat.name}</MaterialCard>)
    }
    return <div
        style={{
            paddingLeft: navOpen ? "250px" : "50px",
            paddingRight: "50px",
            paddingTop: "40px",
            display: "flex",
            justifyContent: "start",
            alignItems: "start",
            background: "#424242",
        }}>
        {/* Frequently used materials */}
        <div style={{ minHeight: "105vh", display: "flex", justifyContent: "start", alignItems: "center", flexDirection: "column" }}>
            <Typography color="primary" variant="h4">Často používané produkty</Typography>
            <TextField sx={{ margin: "20px", width: "95%" }} label="Vyhledat" variant="outlined" />
            {often_material_cards}
            <Button sx={{ margin: "10px" }} variant="contained">Načíst více materiálů</Button>
        </div>
        <div style={{ display: "flex", flexGrow: "1", alignItems: "center", flexDirection: "column", paddingTop: "50px" }}>
            <ChartCard />
        </div>
        {/* Missing materials */}
        <div style={{ minHeight: "105vh", display: "flex", justifyContent: "start", alignItems: "center", flexDirection: "column" }}>
            <Typography color="primary" variant="h4">Nejméně na skladě</Typography>
            <TextField sx={{ margin: "20px", width: "95%" }} label="Vyhledat" variant="outlined" />
            {least_material_cards}
            <Button sx={{ margin: "10px" }} variant="contained">Načíst více materiálů</Button>
        </div>
    </div>
}

export default Home;