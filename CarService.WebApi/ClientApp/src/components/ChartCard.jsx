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
const ChartCard = (props) => {
    const labels = ['January', 'February', 'March', 'March', 'March'];
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
                data: [1, 8, 3, 15, 1],
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