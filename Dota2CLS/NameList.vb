Module NameList

    Public Function search(ByVal input As String)
        Dim output As String = ""

        If input.Contains("hero") Then
            output = Heroesfunc(input)
        ElseIf input.Contains("modifier") Then
            output = input
        ElseIf input.Contains("item") Then
            output = input
        ElseIf (input.Contains("neutral") Or input.Contains("badguys") Or input.Contains("goodguys") Or input.Contains("courier") Or input.Contains("roshan") Or _
                input.Contains("fountain")) Then
            output = input
        ElseIf input.Contains("ALLSKILSHERE") Then
            output = input
        Else
            output = input & " checkthis!"
        End If

        Return output
    End Function

    Private Function Heroesfunc(ByVal input As String)
        'Heroes
        Dim Heroes() As String = {"'npc_dota_hero_antimage'", _
                                  "'npc_dota_hero_axe'", _
                                  "'npc_dota_hero_bane'", _
                                  "'npc_dota_hero_bloodseeker'", _
                                  "'npc_dota_hero_crystal_maiden'", _
                                  "'npc_dota_hero_drow_ranger'", _
                                  "'npc_dota_hero_earthshaker'", _
                                  "'npc_dota_hero_juggernaut'", _
                                  "'npc_dota_hero_mirana'", _
                                  "'npc_dota_hero_nevermore'", _
                                  "'npc_dota_hero_morphling'", _
                                  "'npc_dota_hero_phantom_lancer'", _
                                  "'npc_dota_hero_puck'", _
                                  "'npc_dota_hero_pudge'", _
                                  "'npc_dota_hero_razor'", _
                                  "'npc_dota_hero_sand_king'", _
                                  "'npc_dota_hero_storm_spirit'", _
                                  "'npc_dota_hero_sven'", _
                                  "'npc_dota_hero_tiny'", _
                                  "'npc_dota_hero_vengefulspirit'", _
                                  "'npc_dota_hero_windrunner'", _
                                  "'npc_dota_hero_zuus'", _
                                  "'npc_dota_hero_kunkka'", _
                                  "'npc_dota_hero_lina'", _
                                  "'npc_dota_hero_lich'", _
                                  "'npc_dota_hero_lion'", _
                                  "'npc_dota_hero_shadow_shaman'", _
                                  "'npc_dota_hero_slardar'", _
                                  "'npc_dota_hero_tidehunter'", _
                                  "'npc_dota_hero_witch_doctor'", _
                                  "'npc_dota_hero_riki'", _
                                  "'npc_dota_hero_enigma'", _
                                  "'npc_dota_hero_tinker'", _
                                  "'npc_dota_hero_sniper'", _
                                  "'npc_dota_hero_necrolyte'", _
                                  "'npc_dota_hero_warlock'", _
                                  "'npc_dota_hero_beastmaster'", _
                                  "'npc_dota_hero_queenofpain'", _
                                  "'npc_dota_hero_venomancer'", _
                                  "'npc_dota_hero_faceless_void'", _
                                  "'npc_dota_hero_skeleton_king'", _
                                  "'npc_dota_hero_death_prophet'", _
                                  "'npc_dota_hero_phantom_assassin'", _
                                  "'npc_dota_hero_pugna'", _
                                  "'npc_dota_hero_templar_assassin'", _
                                  "'npc_dota_hero_viper'", _
                                  "'npc_dota_hero_luna'", _
                                  "'npc_dota_hero_dragon_knight'", _
                                  "'npc_dota_hero_dazzle'", _
                                  "'npc_dota_hero_rattletrap'", _
                                  "'npc_dota_hero_leshrac'", _
                                  "'npc_dota_hero_furion'", _
                                  "'npc_dota_hero_life_stealer'", _
                                  "'npc_dota_hero_dark_seer'", _
                                  "'npc_dota_hero_clinkz'", _
                                  "'npc_dota_hero_omniknight'", _
                                  "'npc_dota_hero_enchantress'", _
                                  "'npc_dota_hero_huskar'", _
                                  "'npc_dota_hero_night_stalker'", _
                                  "'npc_dota_hero_broodmother'", _
                                  "'npc_dota_hero_bounty_hunter'", _
                                  "'npc_dota_hero_weaver'", _
                                  "'npc_dota_hero_jakiro'", _
                                  "'npc_dota_hero_batrider'", _
                                  "'npc_dota_hero_chen'", _
                                  "'npc_dota_hero_spectre'", _
                                  "'npc_dota_hero_doom_bringer'", _
                                  "'npc_dota_hero_ancient_apparition'", _
                                  "'npc_dota_hero_ursa'", _
                                  "'npc_dota_hero_spirit_breaker'", _
                                  "'npc_dota_hero_gyrocopter'", _
                                  "'npc_dota_hero_alchemist'", _
                                  "'npc_dota_hero_invoker'", _
                                  "'npc_dota_hero_silencer'", _
                                  "'npc_dota_hero_obsidian_destroyer'", _
                                  "'npc_dota_hero_lycan'", _
                                  "'npc_dota_hero_brewmaster'", _
                                  "'npc_dota_hero_shadow_demon'", _
                                  "'npc_dota_hero_lone_druid'", _
                                  "'npc_dota_hero_chaos_knight'", _
                                  "'npc_dota_hero_meepo'", _
                                  "'npc_dota_hero_treant'", _
                                  "'npc_dota_hero_ogre_magi'", _
                                  "'npc_dota_hero_undying'", _
                                  "'npc_dota_hero_rubick'"}



        Dim Heroesout() As String = {"Antimage", _
                                     "Axe", _
                                     "Bane", _
                                     "Bloodseeker", _
                                     "Crystal Maiden", _
                                     "Drow Ranger", _
                                     "Earthshaker", _
                                     "Juggernaut", _
                                     "Mirana", _
                                     "Nevermore", _
                                     "Morphling", _
                                     "Phantom Lancer", _
                                     "Puck", _
                                     "Pudge", _
                                     "Razor", _
                                     "Sand King", _
                                     "Storm Spirit", _
                                     "Sven", _
                                     "Tiny", _
                                     "Vengeful Spirit", _
                                     "Windrunner", _
                                     "Zeus", _
                                     "Kunkka", _
                                     "Lina", _
                                     "Lich", _
                                     "Lion", _
                                     "Shadow Shaman", _
                                     "Slardar", _
                                     "Tidehunter", _
                                     "Witch Doctor", _
                                     "Riki", _
                                     "Enigma", _
                                     "Tinker", _
                                     "Sniper", _
                                     "Necrolyte", _
                                     "Warlock", _
                                     "Beastmaster", _
                                     "Queen of Pain", _
                                     "Venomancer", _
                                     "Faceless Void", _
                                     "Skeleton King", _
                                     "Death Prophet", _
                                     "Phantom Assassin", _
                                     "Pugna", _
                                     "Templar Assassin", _
                                     "Viper", _
                                     "Luna", _
                                     "Dragon Knight", _
                                     "Dazzle", _
                                     "Rattletrap", _
                                     "Leshrac", _
                                     "Furion", _
                                     "Lifestealer", _
                                     "Dark Seer", _
                                     "Clinkz", _
                                     "Omniknight", _
                                     "Enchantress", _
                                     "Huskar", _
                                     "Night Stalker", _
                                     "Broodmother", _
                                     "Bounty Hunter", _
                                     "Weaver", _
                                     "Jakiro", _
                                     "Batrider", _
                                     "Chen", _
                                     "Spectre", _
                                     "Doom Bringer", _
                                     "Ancient Apparition", _
                                     "Ursa", _
                                     "Spirit Breaker", _
                                     "Gyrocopter", _
                                     "Alchemist", _
                                     "Invoker", _
                                     "Silencer", _
                                     "Obsidian Destroyer", _
                                     "Lycan", _
                                     "Brewmaster", _
                                     "Shadow Demon", _
                                     "Lone Druid", _
                                     "Chaos Knight", _
                                     "Meepo", _
                                     "Treant Protector", _
                                     "Ogre Magi", _
                                     "Undying", _
                                     "Rubick"}
        Return Heroesout((Array.FindIndex(Heroes, Function(x) x.Contains(input)))).ToString

    End Function


End Module
