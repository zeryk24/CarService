
import { LinearProgress, Card, CardContent, Button, Typography, Divider, CardActions, Dialog, DialogTitle, DialogContent, TextField, DialogActions, Snackbar, Alert, Switch, FormControlLabel, Fab, Collapse } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import LayoutContext from "../components/LayoutContext";
import MechanicFasade from "../fasades/MechanicFasade"
import PersonOutlineIcon from '@mui/icons-material/PersonOutline';
import { Add } from "@mui/icons-material";

const EditingDialog = (props) => {
    let mechanic = props.mechanic;
    const [name, setName] = useState("");
    const [liv, setLiv] = useState("");
    const [phone, setPhone] = useState("");
    const [painter, setpainter] = useState(false);
    const [engine, setEngine] = useState(false);
    const [plum, setPlum] = useState();
    const [loaded, setLoaded] = useState(true);
    const [show, setShow] = useState(true);
    let editing = mechanic != null;
    const SendUpdate = () => {
        setShow(false);
        const fasade = new MechanicFasade();
        if (!editing) mechanic = {};
        mechanic.name = name;
        mechanic.residencePlace = liv;
        mechanic.phoneNumber = phone;
        mechanic.engineSpecialist = engine;
        mechanic.carPlumber = plum;
        mechanic.carPainter = painter;
        if (editing) {
            fasade.Update(mechanic).then((data) => {
                setLoaded(true);
            })
        }
        else {
            fasade.Create(mechanic).then((data) => {
                setLoaded(true);
            })
        }
    }
    useEffect(() => {
        if (!editing) {
            setName("");
            setLiv("");
            setPhone("");
            setEngine(false);
            setPlum(false);
            setpainter(false);
        }
        else {
            setName(mechanic.name);
            setLiv(mechanic.residencePlace);
            setPhone(mechanic.phoneNumber);
            setEngine(mechanic.engineSpecialist);
            setPlum(mechanic.carPlumber);
            setpainter(mechanic.carPainter);
        }
        setLoaded(false);
        setShow(true);
    }, [props]);

    return <Dialog
        open={props.openModal}
        onClose={() => { props.onClose(); props.setOpenModal(false) }}>
        <DialogTitle color="primary">
            <TextField sx={{ margin: "10px" }} label="Jméno" variant="outlined" value={name} onChange={(e) => { setName(e.target.value) }} />
        </DialogTitle>
        <DialogContent>
            <TextField sx={{ margin: "10px" }} multiline rows="3" value={liv} onChange={(e) => { setLiv(e.target.value) }} label="Bydliště" />
            <TextField sx={{ margin: "10px" }} value={phone} onChange={(e) => { setPhone(e.target.value) }} label="Telefoní číslo" placeholder="+420 777 777 777" /><br />
            <FormControlLabel sx={{ margin: "10px" }} control={<Switch checked={engine} onChange={() => { setEngine(!engine) }} />} label="Motorový specialista" /><br />
            <FormControlLabel sx={{ margin: "10px" }} control={<Switch checked={painter} />} onChange={() => { setpainter(!painter) }} label="Autolakýrník" /><br />
            <FormControlLabel sx={{ margin: "10px" }} control={<Switch checked={plum} />} onChange={() => { setPlum(!plum) }} label="Autoklempíř" />
        </DialogContent>
        <DialogActions>
            {show ? <Button variant="outlined" onClick={SendUpdate}>Uložit</Button> : ""}
        </DialogActions>
        <Snackbar
            anchorOrigin={{ horizontal: "center", vertical: "bottom" }}
            open={loaded}
            onClose={() => {
                setLoaded(false)
                props.onClose();
                props.setOpenModal(false)
            }}
            autoHideDuration={1000}
        >
            <Alert severity="success">
                Úspěšně uloženo!
            </Alert>
        </Snackbar>
    </Dialog>
}
function IsSubstring(substring, string) {
    substring = substring.toLowerCase();
    string = string.toLowerCase();
    return string.includes(substring);
}
const MechanicCard = (props) => {
    const card_height = "50px"
    const mechanic = props.mechanic;
    const margin = "20px"
    const white = "#dddddd";
    const [openModal, setOpenModal] = useState(false);
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
    if (repairs.length == 0) {
        repairs.push(<Typography variant="h6" color={white}>
            Tento mechanik nemá přiděleny žádné opravy
        </Typography>)
    }
    return <Card sx={{ margin: "30px" }}>
        <CardContent>
            <div style={{
                width: "100%",
                display: "flex",
                justifyContent: "start",
                alignItems: "stretch",

            }}>
                <div style={{ margin: margin, textAlign: "center", width: "15%" }}>
                    <PersonOutlineIcon color="primary" style={{ width: card_height, height: card_height }} />
                    <Typography variant="h5" color="primary">{mechanic.name}</Typography>

                </div>
                <div style={{ margin: margin, width: "25%" }}>
                    <Typography variant="h5" color="primary">Kontaktní informace</Typography>
                    <Typography variant="h6" color="primary">Bydliště: <b style={{ color: white }}><br />{mechanic.residencePlace}</b></Typography>
                    <Typography variant="h6" color="primary">Tel. číslo: <b style={{ color: white }}><br />{mechanic.phoneNumber}</b></Typography>
                </div>
                <div style={{ margin: margin, width: "20%" }}>
                    <Typography variant="h5" color="primary">Specializace</Typography>

                    <Typography variant="h6" color="primary"><b style={{ color: white }}>{mechanic.carPlumber ? "Autoklempíř" : ""}</b></Typography>
                    <Typography variant="h6" color="primary"><b style={{ color: white }}>{mechanic.carPainter ? "Autolakýrník" : ""}</b></Typography>
                    <Typography variant="h6" color="primary"><b style={{ color: white }}>{mechanic.engineSpecialist ? "Motorový specialista" : ""}</b></Typography>
                </div>
                <div style={{ margin: margin }}>
                    <Typography variant="h5" color="primary">Celkem oprav v systému: <b style={{ color: white }}>{mechanic.repairs.length}</b></Typography>
                    <Typography variant="h5" color="primary">Celkem hotových oprav: <b style={{ color: white }}>{mechanic.repairs.length}</b></Typography>

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
            <Button fullWidth onClick={() => {
                setOpenModal(true);
            }}>Upravit</Button>
        </CardActions>
        <EditingDialog onClose={() => {
            props.onUpdate();
        }} openModal={openModal} setOpenModal={setOpenModal} mechanic={mechanic} />
    </Card>
};


const AllMechanics = () => {
    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);
    const [mechanics, setMechanics] = useState([]);
    const [openModal, setOpenModal] = useState(false);
    const [search, setSearch] = useState("");
    const [col, setCol] = useState(false);
    const fasade = new MechanicFasade();
    const UpdateData = () => {
        fasade.GetAll().then((data) => {
            setMechanics(data)
            setCol(true);
        });
    }
    useEffect(() => {
        setSiteName("Správa zaměstnanců");
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
        let show = false;
        if (IsSubstring(search, mechanic.name)
            || IsSubstring(search, mechanic.residencePlace)) {
            show = true;
        };
        if (mechanic.engineSpecialist && IsSubstring(search, "Motorový specialista")) show = true;
        if (mechanic.carPlumber && IsSubstring(search, "Autoklempíř")) show = true;
        if (mechanic.carPainter && IsSubstring(search, "Autolakýrník")) show = true;
        if (show) {
            mechanic_cards.push(<MechanicCard onUpdate={UpdateData} key={k++} mechanic={mechanic} />)
        }
    }
    return <div style={{
        minHeight: "105vh",
        background: "#424242",
        paddingLeft: navOpen ? "250px" : "50px",
        paddingRight: "50px",
        paddingTop: "40px",
        paddingBottom: "100px"
    }}>
        <TextField value={search} onChange={(e) => { setSearch(e.target.value) }} sx={{ margin: "30px", marginBottom: "0px", marginTop: "0px" }} label="Vyhledat" />
        <Collapse timeout={1000} in={col}>
            {mechanic_cards}
        </Collapse>
        <Fab onClick={() => {
            setOpenModal(true);
        }} color="primary" aria-label="add" sx={{ position: "fixed", bottom: "50px", right: "50px" }}>
            <Add />
        </Fab>
        <EditingDialog onClose={() => {
            UpdateData();
        }} openModal={openModal} setOpenModal={setOpenModal} mechanic={null} />
    </div>
}

export default AllMechanics;