import React from "react";
import {
  Box,
  Flex,
  Button,
  HStack,
  Stack,
  useColorModeValue,
  useColorMode,
  useDisclosure,
  Menu,
  MenuButton,
  Avatar,
  MenuList,
  Center,
  MenuDivider,
  MenuItem,
  Text,
} from "@chakra-ui/react";

import { MoonIcon, SunIcon } from "@chakra-ui/icons";

import Logo from "./Logo";
import MenuToggler from "./MenuToggler";
import DesktopNav from "./DesktopNav";
import MobileNav from "./MobileNav";

import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { logoutRequest } from "../../redux/auth";

const Links = [
  { path: "/", content: "Home" },
  { path: "/search", content: "Search" },
  { path: "/properties", content: "Properties" },
];

const NavBar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  const { isOpen, onOpen, onClose } = useDisclosure();

  const navigate = useNavigate();

  const { isAuthenticated, email, token } = useSelector(state => state.auth);

  const dispatch = useDispatch();

  const logoutHandler = () => {
    dispatch(logoutRequest({ token }));
    navigate("/signin", { replace: true });
  };

  return (
    <>
      <Box bg={useColorModeValue("gray.100", "gray.900")} px={4}>
        <Flex h={16} alignItems={"center"} justifyContent={"space-between"}>
          <MenuToggler isOpen={isOpen} onOpen={onOpen} onClose={onClose} />
          <HStack spacing={8} alignItems={"center"}>
            <Logo title='Aqar' />

            <DesktopNav items={Links} />
          </HStack>
          <Flex alignItems={"center"}>
            <Stack
              flex={{ base: 1, md: 0 }}
              justify={"flex-end"}
              direction={"row"}
              spacing={6}
            >
              <Button
                display={{ base: "none", md: "flex" }}
                onClick={toggleColorMode}
              >
                {colorMode === "light" ? <MoonIcon /> : <SunIcon />}
              </Button>
              {!isAuthenticated && (
                <Button
                  fontSize={"sm"}
                  fontWeight={400}
                  variant={"link"}
                  onClick={() => navigate("/signin", { replace: true })}
                >
                  Sign In
                </Button>
              )}
              {!isAuthenticated && (
                <Button
                  display={{ base: "none", md: "flex" }}
                  fontSize={"sm"}
                  fontWeight={600}
                  color={"white"}
                  bg={"teal.400"}
                  onClick={() => navigate("/signup", { replace: true })}
                  _hover={{
                    bg: "teal.300",
                  }}
                >
                  Sign Up
                </Button>
              )}
              {isAuthenticated && (
                <Menu>
                  <MenuButton
                    as={Button}
                    rounded={"full"}
                    variant={"link"}
                    cursor={"pointer"}
                    minW={0}
                  >
                    <Avatar
                      size={"sm"}
                      src={"https://avatars.dicebear.com/api/male/username.svg"}
                    />
                  </MenuButton>
                  <MenuList alignItems={"center"}>
                    <br />
                    <Center>
                      <Avatar
                        size={"2xl"}
                        src={
                          "https://avatars.dicebear.com/api/male/username.svg"
                        }
                      />
                    </Center>
                    <br />
                    <Center>
                      <p>{email}</p>
                    </Center>
                    <br />
                    <MenuDivider />
                    <MenuItem onClick={logoutHandler}>Logout</MenuItem>
                  </MenuList>
                </Menu>
              )}
            </Stack>
          </Flex>
        </Flex>

        {isOpen ? (
          <Box display={{ md: "none" }}>
            <MobileNav
              items={Links}
              colorMode={colorMode}
              toggleColorMode={toggleColorMode}
            />
          </Box>
        ) : null}
      </Box>
    </>
  );
};

export default NavBar;
