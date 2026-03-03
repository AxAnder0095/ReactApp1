/* eslint-disable react-hooks/set-state-in-effect */
import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [transactions, setTransactions] = useState([]);

    async function fetchTransactions() {

        try {
            const res = await fetch('api/UserTransaction');
            if (res.ok) {
                const data = await res.json();
                setTransactions(data);
            }
        } catch (error) {
            console.error('Error fetching transactions:', error);
        }
    }

    
    useEffect(() => {
        fetchTransactions();
    }, []);

    return (
        <div className="App">
            {transactions.length === 0 ? (
                <p>Loading Transations</p>
            ) : (
                transactions.map((item) => (
                    <div key={ item.id} >
                        <p>{ item.source}</p>
                    </div>))

            )}
        </div>
    );
}

export default App;