import { useState } from "react";
import {
  Flex,
  Text,
  Box,
  FormControl,
  FormLabel,
  Input,
  Stack,
  Button,
  Heading,
  useColorModeValue,
  Alert,
  AlertIcon,
  AlertTitle,
} from "@chakra-ui/react";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { login } from "../redux/auth";

export default function SignIn() {
  const [account, setAccount] = useState({
    email: "",
    password: "",
  });

  const { error } = useSelector(state => state.auth);

  const dispatch = useDispatch();

  const LoginHandler = e => {
    e.preventDefault();
    dispatch(login(account));
  };

  const inputChangeHandler = ({ currentTarget: input }) => {
    const enteredAccount = { ...account };
    enteredAccount[input.name] = input.value;
    setAccount(enteredAccount);
  };

  return (
    <Flex
      minH={"100vh"}
      align={"center"}
      justify={"center"}
      bg={useColorModeValue("gray.50", "gray.800")}
    >
      <Stack spacing={8} mx={"auto"} maxW={"lg"} py={12} px={6}>
        {error && (
          <Alert status='error'>
            <AlertIcon />
            <AlertTitle mr={2}>{error}</AlertTitle>
          </Alert>
        )}

        <Stack align={"center"}>
          <Heading fontSize={"4xl"}>Sign in to your account</Heading>
        </Stack>
        <form onSubmit={LoginHandler}>
          <Box
            rounded={"lg"}
            bg={useColorModeValue("white", "gray.700")}
            boxShadow={"lg"}
            p={8}
          >
            <Stack spacing={4}>
              <FormControl id='email'>
                <FormLabel>Email address</FormLabel>
                <Input
                  type='email'
                  name='email'
                  value={account.email}
                  onChange={inputChangeHandler}
                />
              </FormControl>
              <FormControl id='password'>
                <FormLabel>Password</FormLabel>
                <Input
                  type='password'
                  name='password'
                  value={account.password}
                  onChange={inputChangeHandler}
                />
              </FormControl>
              <Stack spacing={10}>
                <Stack
                  direction={{ base: "column", sm: "row" }}
                  align={"start"}
                  justify={"space-between"}
                >
                  <Link to='/signup'>
                    <Text color={"blue.400"}>Create New Account.</Text>
                  </Link>
                </Stack>
                <Button
                  type='submit'
                  bg={"blue.400"}
                  color={"white"}
                  _hover={{
                    bg: "blue.500",
                  }}
                >
                  Sign in
                </Button>
              </Stack>
            </Stack>
          </Box>
        </form>
      </Stack>
    </Flex>
  );
}
