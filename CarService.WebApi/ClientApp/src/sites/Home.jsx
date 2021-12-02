import { Card, CardContent, Paper, Typography, Button, TextField, LinearProgress, Collapse } from "@mui/material";
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
                <Button sx={{ margin: "5px" }} onClick={() => {
                    props.setDetail(props.material)
                }} variant="outlined">Zobrazit spotřebu</Button>
            </div>
        </CardContent>
    </Card >
}

function IsSubstring(substring, string) {
    substring = substring.toLowerCase();
    string = string.toLowerCase();
    return string.includes(substring);
}

const Home = (props) => {
    const fasade = new MaterialsFasade();

    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);
    const [oftenMaterials, setOftenMaterials] = useState([]);
    const [leastMaterials, setLeastMaterials] = useState([]);
    const [oftenSeach, setOftenSeach] = useState("");
    const [leastSeach, setLeastSeach] = useState("");
    const [maxItems, setMaxItems] = useState(4);
    const [colps, setColps] = useState(false);
    const [chartMaterial, setChartMaterial] = useState(0);
    useEffect(() => {
        setSiteName("Analýza spotřeby materiálů")
        fasade.GetAll().then((data) => {

            data = data.sort((a, b) => {
                return a.consumes.length < b.consumes.length ? 1 : -1;
            });
            setChartMaterial(data[0])
            setOftenMaterials(data);
            data = [...data];
            data = data.sort((a, b) => {
                return a.stockQuantity > b.stockQuantity ? 1 : -1;
            });
            setLeastMaterials(data);
            setColps(true);
        })
    }, []);
    if (oftenMaterials.length == 0) {
        return <div style={{ background: "#424242", height: "100%" }}>
            <LinearProgress />
        </div>
    }

    let often_material_cards = [];
    let k = 0;
    for (let mat of oftenMaterials) {
        if (oftenSeach !== "" && !IsSubstring(oftenSeach, mat.name)) continue;
        often_material_cards.push(<MaterialCard key={k++} setDetail={setChartMaterial} material={mat} amount={mat.stockQuantity}>{mat.name}</MaterialCard>)
        if (k == maxItems) {
            break;
        }
    }
    let least_material_cards = [];
    k = 0;
    for (let mat of leastMaterials) {
        if (leastSeach !== "" && !IsSubstring(leastSeach, mat.name)) continue;
        least_material_cards.push(<MaterialCard key={k++} setDetail={setChartMaterial} material={mat} amount={mat.stockQuantity}>{mat.name}</MaterialCard>)
        if (k == maxItems) {
            break;
        }
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
        <div style={{ minHeight: "155vh", display: "flex", justifyContent: "start", alignItems: "center", flexDirection: "column" }}>
            <Typography color="primary" variant="h4" sx={{ width: "420px" }}>Často používané produkty</Typography>
            <TextField value={oftenSeach} onChange={(e) => { setOftenSeach(e.target.value) }} sx={{ margin: "20px", width: "95%" }} label="Vyhledat" variant="outlined" />
            <Collapse in={colps} timeout={500}>
                {often_material_cards}
            </Collapse>
            {maxItems > often_material_cards.length ? "" :
                <Button sx={{ margin: "10px" }} onClick={() => { setMaxItems(maxItems + 4) }} variant="contained">Načíst více materiálů</Button>
            }
        </div>
        <div style={{ overflow: "hidden", display: "flex", flexGrow: "1", alignItems: "center", flexDirection: "column", paddingTop: "50px" }}>
            <ChartCard material={chartMaterial} />
        </div>
        {/* Missing materials */}
        <div style={{ minHeight: "105vh", display: "flex", justifyContent: "start", alignItems: "center", flexDirection: "column" }}>
            <Typography color="primary" variant="h4" sx={{ width: "420px" }}>Nejméně na skladě</Typography>
            <TextField value={leastSeach} onChange={(e) => { setLeastSeach(e.target.value) }} sx={{ margin: "20px", width: "95%" }} label="Vyhledat" variant="outlined" />
            <Collapse in={colps} timeout={500}>
                {least_material_cards}
            </Collapse>
            {maxItems > least_material_cards.length ? "" :
                <Button sx={{ margin: "10px" }} onClick={() => { setMaxItems(maxItems + 4) }} variant="contained">Načíst více materiálů</Button>
            }        </div>
    </div>
}

export default Home;