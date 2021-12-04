import { Collapse, Dialog, Button, DialogActions, DialogContent, DialogTitle, Divider, LinearProgress, List, ListItem, Paper, TableBody, TableCell, TableContainer, TableHead, TableRow, TextField, Typography, Alert, Fab } from "@mui/material";
import { useContext, useEffect, useState } from "react";
import LayoutContext from "../components/LayoutContext";
import MaterialsFasade from "../fasades/MaterialsFasade";
import { DataGrid } from '@mui/x-data-grid';
import { Table } from "reactstrap";
import Snackbar from '@mui/material/Snackbar';
import { Add } from "@mui/icons-material";
import EditIcon from '@mui/icons-material/Edit';
const EditingDialog = (props) => {
    let material = props.material;
    const [name, setName] = useState("");
    const [desc, setDesc] = useState("");
    const [amount, setAmount] = useState(0);
    const [loaded, setLoaded] = useState(true);
    let editing = material != null;
    const SendUpdate = () => {
        const fasade = new MaterialsFasade();
        if (!editing) material = {};
        material.name = name;
        material.description = desc;
        material.stockQuantity = amount;
        if (editing) {
            fasade.Update(material).then((data) => {
                setLoaded(true);
            })
        }
        else {
            fasade.Create(material).then((data) => {
                setLoaded(true);
            })
        }
    }
    useEffect(() => {
        if (!editing) {
            setName("");
            setDesc("");
            setAmount(0);
        }
        else {

            setName(material.name);
            setDesc(material.description);
            setAmount(material.stockQuantity);
        }
        setLoaded(false);
    }, [props]);

    return <Dialog
        open={props.openModal}
        onClose={() => { props.onClose(); props.setOpenModal(false) }}>
        <DialogTitle color="primary">
            <TextField sx={{ margin: "10px" }} label="Jméno" variant="outlined" value={name} onChange={(e) => { setName(e.target.value) }} />
        </DialogTitle>
        <DialogContent>
            <TextField sx={{ margin: "10px", width: "80%" }} multiline minRows={7} label="Jméno" variant="outlined" value={desc} onChange={(e) => { setDesc(e.target.value) }} />
            <TextField type="number" sx={{ margin: "10px" }} value={amount} onChange={(e) => { setAmount(e.target.value) }} label="Počet na skladě" />
        </DialogContent>
        <DialogActions>
            <Button variant="outlined" onClick={SendUpdate}>Uložit</Button>
        </DialogActions>
        <Snackbar

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

const MaterialTableRow = (props) => {
    let mat = props.material;
    let sum = 0;
    let positive = mat.stockQuantity > 10;
    for (let cons of mat.consumes) {
        sum += cons.amount;
    }
    let material = props.material;
    const [amount, setAmount] = useState("");
    const [loaded, setLoaded] = useState(false);
    const SendUpdate = () => {
        const fasade = new MaterialsFasade();
        if (amount == "") return;
        material.stockQuantity += parseInt(amount);

        fasade.Update(material).then((data) => {
            setLoaded(true);
            setAmount("");
        });
    }
    return <TableRow hover>
        <TableCell onClick={() => {
            props.onClick(mat)
        }}>
            <Typography>
                <Button><EditIcon color="primary" /> </Button>{mat.name}
            </Typography>
        </TableCell>
        <TableCell>
            <Typography color={positive ? "lightgreen" : "lightsalmon"}>
                {mat.stockQuantity}
            </Typography>
        </TableCell>
        <TableCell>
            <Typography>
                {mat.consumes.length}
            </Typography>
        </TableCell>
        <TableCell>
            <Typography>
                {sum} Ks
            </Typography>
        </TableCell>
        <TableCell style={{ display: "flex", alignItems: "center" }}>
            <TextField type="number" value={amount} onChange={(e) => { setAmount(e.target.value) }} size="small" label="Množštví" variant="filled" />
            <Button onClick={SendUpdate}><Add /></Button>
            <Snackbar
                open={loaded}
                onClose={() => {
                    setLoaded(false)
                }}
                autoHideDuration={1000}
            >
                <Alert severity="success">
                    Úspěšně uloženo!
                </Alert>
            </Snackbar>
        </TableCell>
    </TableRow>
}
function IsSubstring(substring, string) {
    substring = substring.toLowerCase();
    string = string.toLowerCase();
    return string.includes(substring);
}
const AllMaterials = () => {
    const [colps, setColps] = useState(false);
    const fasade = new MaterialsFasade();
    const { navOpen, setNavOpen, siteName, setSiteName } = useContext(LayoutContext);
    const [materials, setMaterials] = useState([]);
    const [search, setSearch] = useState("");
    const [openModal, setOpenModal] = useState(false);
    const [clickedMaterial, setClieckedMaterial] = useState(null);
    useEffect(() => {
        Reload();
    }, [])
    const Reload = () => {
        console.log("reloaded")
        fasade.GetAll().then((data) => {
            setMaterials(data);
            setColps(true);
            setClieckedMaterial(data[0]);
        });
    }
    const OnRowClick = (material) => {
        setClieckedMaterial(material);
        setOpenModal(true);
    }

    if (materials.length == 0) {
        return <div style={{ background: "#424242", height: "100%" }}>
            <LinearProgress />
        </div>
    }
    let table_rows = [];
    let k = 0;
    for (let mat of materials) {
        if (!IsSubstring(search, mat.name)) continue;
        table_rows.push(<MaterialTableRow onClick={OnRowClick} material={mat} key={k++} />);
    }
    setSiteName("Správa všech materiálů v systému")
    return <div style={{
        paddingLeft: navOpen ? "250px" : "50px",
        paddingRight: "50px",
        paddingTop: "40px",
        display: "flex",
        justifyContent: "start",
        alignItems: "start",
        background: "#424242",
        minHeight: "105vh"
    }}>
        <TableContainer component={Paper}>
            <Collapse timeout={500} in={colps}>
                <Table>
                    <TableHead>
                        <TableRow >
                            <TableCell>
                                <TextField value={search} onChange={(e) => { setSearch(e.target.value) }} label="Jméno" variant="outlined" />
                            </TableCell>
                            <TableCell>
                                <Typography color="primary">
                                    Počet na skladě
                                </Typography>
                            </TableCell>
                            <TableCell>
                                <Typography color="primary">
                                    Kolikrát použito
                                </Typography>
                            </TableCell>
                            <TableCell>
                                <Typography color="primary">
                                    Kolik použito
                                </Typography>
                            </TableCell>
                            <TableCell>
                                <Typography textAlign="center" color="primary">
                                    Naskladnit
                                </Typography>
                            </TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {table_rows}
                    </TableBody>
                </Table>
            </Collapse>
        </TableContainer>
        <Fab onClick={() => {
            setClieckedMaterial(null);
            setOpenModal(true);
        }} color="primary" aria-label="add" sx={{ position: "fixed", bottom: "50px", right: "50px" }}>
            <Add />
        </Fab>
        <EditingDialog onClose={Reload} openModal={openModal} setOpenModal={setOpenModal} material={clickedMaterial} />
    </div>
}

export default AllMaterials;