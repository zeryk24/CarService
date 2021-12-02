import { Card, CardContent, Typography, Button } from "@mui/material";
import { Line } from "react-chartjs-2";
import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from 'chart.js';
import { minWidth } from "@mui/system";
import MaterialsFasade from "../fasades/MaterialsFasade"
import { useEffect, useState } from "react";
const ChartCard = (props) => {
    const fasade = new MaterialsFasade();
    const labels = ['Leden', 'Únor', 'Březen', 'Duben', 'Květen', "Červen", "Červenec", "Srpen", "Září", "Říjen", "Listopad", "Prosinec"];
    let consumes = props.material.consumes;
    const [raw_data, set_data] = useState([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0])
    const [fetched_index, set_fetched_index] = useState(-1);
    const GetData = (index) => {
        if (index <= consumes.length - 1) {
            fasade.GetDate(consumes[index].activityId).then((data) => {
                let a = new Date(data.split("T")[0]);
                let c = [...raw_data];
                c[a.getMonth()] += consumes[index].amount;
                set_data(c);

            })
        }
    }
    useEffect(() => {
        let index = 1 + fetched_index;
        set_fetched_index(index);
        GetData(index);
    }, [raw_data])
    ChartJS.register(
        CategoryScale,
        LinearScale,
        PointElement,
        LineElement,
        //      Title,
        Tooltip,
        //Legend
    );
    const data = {
        labels,
        datasets: [
            {
                // label: 'Spotřeba',
                data: raw_data,
                backgroundColor: "#e65100",
                borderColor: '#e65100',
            },
        ],
    };

    return <Card
        sx={
            {
                width: "80%",
                minWidth: "300px",
            }
        }
    >
        <CardContent>
            <Typography variant="h6" color="primary" textAlign="center">Shell Helix HX7 5W-40 4L</Typography>
            <Line options={{ color: "#bbbbbb" }} data={data} />
            <Typography sx={{ margin: "15px" }} variant="h6" color="primary">
                Popis produktu
            </Typography>
            <Typography sx={{ margin: "15px" }} variant="body1" color="primary">
                Shell Helix HX7 5W-40 je motorový olej pro nejmodernější benzínové,dieselové a plynové motory osobních a lehkých užitkových automobilů. Je vhodný pro nepřeplňované a přeplňované motory, motory s přímým vstřikováním či víceventilové motory.
            </Typography>
            <Button sx={{ margin: "15px" }} variant="outlined" size="large">Objednat</Button>
        </CardContent>
    </Card >
}

export default ChartCard;