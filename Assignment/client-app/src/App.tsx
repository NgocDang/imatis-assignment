import './App.css';
import { Row, Spinner } from 'react-bootstrap';
import Customer from './components/Customer/Customer';
import Package from './components/Package/Package';
import Summary from './components/Summary/Summary';
import useStore from './app/store';
import { useCallback, useEffect } from 'react';

function App() {
  const isLoading = useStore((state) => state.isLoading);
  const { selectCustomer, queryCustomers, setLoading, queryPackages } =
    useStore((state) => state);

  const fetchData = useCallback(async () => {
    setLoading(true);
    await queryCustomers();
    await queryPackages();
    selectCustomer();
    setLoading(false);
  }, []);

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <div className='App'>
      <header>
        <h1>Imatis Assignments</h1>
      </header>
      {isLoading ? (
        <Spinner animation='border' role='status'>
          <span className='visually-hidden'>Loading...</span>
        </Spinner>
      ) : (
        <>
          <Customer />
          <Row xs={1} md={2} lg={3} className='g-4'>
            <Package />
          </Row>
          <Summary />
        </>
      )}
    </div>
  );
}

export default App;
