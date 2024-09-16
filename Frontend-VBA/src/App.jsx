import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import InputField from './Components/SubComponents/InputField/InputField'


function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <InputField
        type="text"
        size="medium"
        icon="search"
        placeholder="Search..." />
    </>
  )
}

export default App
