
import { LinearProgress, Card, CardContent, Button, Typography, Divider, CardActions } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import LayoutContext from "../components/LayoutContext";
import MechanicFasade from "../fasades/MechanicFasade"
import PersonOutlineIcon from '@mui/icons-material/PersonOutline';
const MechanicCard = (props) => {
    const card_height = "50px"
    const mechanic = props.mechanic;
    const margin = "20px 50px"
    const white = "#dddddd";
    let repairs = [];
    let k = 0;
    for (let repair of mechanic.repairs) {
        repairs.push(<div key={k++}>
            <Divider style={{ marginTop: "10px", marginBottom: "10px" }} />
            <Typography variant="h6" color="primary">
                Datum vytvoření:  <b style={{ color: white }}>{new Date(repair.date).toLocaleDateString()}</b>
            </Typography>
            <Typography variant="h6" color={repair.state != 0 ? "lightgreen" : "lightsalmon"}>
                {repair.state == 0 ? "Čeká" : "Probíhá"}
            </Typography>
            <Typography variant="body1">
                {repair.description}
            </Typography>
        </div>
        )
    }
    return <Card>
        <CardContent>
            <div style={{
                width: "100%",
                display: "flex",
                justifyContent: "stretch",
                alignItems: "stretch",

            }}>
                <div style={{ margin: margin, textAlign: "center", minHeight: card_height, minWidth: card_height }}>
                    <PersonOutlineIcon color="primary" style={{ minHeight: card_height, minWidth: card_height }} />
                    <Typography variant="h5" color="primary">{mechanic.name}</Typography>

                </div>
                <div style={{ margin: margin }}>
                    <Typography variant="h5" color="primary">Kontaktní informace</Typography>
                    <Typography variant="h6" color="primary">Bydliště: <b style={{ color: white }}>{mechanic.residencePlace}</b></Typography>
                    <Typography variant="h6" color="primary">Tel. číslo: <b style={{ color: white }}>{mechanic.phoneNumber}</b></Typography>
                </div>
                <div style={{ margin: margin }}>
                    <Typography variant="h5" color="primary">Specializace</Typography>

                    <Typography variant="h6" color="primary"><b style={{ color: white }}>{mechanic.carPlumber ? "Autoklempíř" : ""}</b></Typography>
                    <Typography variant="h6" color="primary"><b style={{ color: white }}>{mechanic.carPainter ? "Autolakýrník" : ""}</b></Typography>
                    <Typography variant="h6" color="primary"><b style={{ color: white }}>{mechanic.engineSpecialist ? "Motorový" : ""}</b></Typography>
                </div>
                <div style={{ margin: margin }}>
                    <Typography variant="h5" color="primary">Celkem oprav v systému: <b style={{ color: white }}>{mechanic.repairs.length}</b></Typography>

                </div>
            </div>
            <div>
                <div style={{ margin: margin }}>
                    <Typography variant="h5" color="primary">Aktivní opravy</Typography>
                    {repairs}
                </div>
            </div>
        </CardContent>
        <CardActions>
            <Button fullWidth>Upravit</Button>
        </CardActions>
    </Card>
};


const AllMechanics = () => {
    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);
    const [mechanics, setMechanics] = useState([]);
    const fasade = new MechanicFasade();
    const UpdateData = () => {
        fasade.GetAll().then((data) => {
            setMechanics(data)
        });
    }
    useEffect(() => {
        UpdateData();
    }, []);
    if (mechanics.length == 0) {
        return <div style={{ background: "#424242", height: "100%" }}>
            <LinearProgress />
        </div>
    }
    let mechanic_cards = [];
    let k = 0;
    for (let mechanic of mechanics) {
        mechanic_cards.push(<MechanicCard key={k++} mechanic={mechanic} />)
    }
    return <div style={{
        minHeight: "105vh",
        background: "#424242",
        paddingLeft: navOpen ? "250px" : "50px",
        paddingRight: "50px",
        paddingTop: "40px"
    }}>
        {mechanic_cards}
    </div>
}

export default AllMechanics;