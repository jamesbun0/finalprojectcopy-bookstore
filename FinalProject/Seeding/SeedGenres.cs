using FinalProject.Models;
using FinalProject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace FinalProject.Seeding
{
	public static class SeedGenres
	{
		public static void SeedAllGenres(AppDbContext db)
		{
			if (db.Genres.Count() == 250)
			{
				throw new NotSupportedException("The database already contains all Genres!");
			}

			Int32 intGenresAdded = 0;
			String genreName = "Begin"; //helps to keep track of error on genres
			List<Genre> Genres = new List<Genre>();

			try
			{
				Genre r1 = new Genre();
				r1.GenreName = "Contemporary Fiction";
				Genres.Add(r1);

				Genre r2 = new Genre();
				r2.GenreName = "Science Fiction";
				Genres.Add(r2);

				Genre r3 = new Genre();
				r3.GenreName = "Mystery";
				Genres.Add(r3);

				Genre r4 = new Genre();
				r4.GenreName = "Suspense";
				Genres.Add(r4);

				Genre r5 = new Genre();
				r5.GenreName = "Romance";
				Genres.Add(r5);

				Genre r6 = new Genre();
				r6.GenreName = "Thriller";
				Genres.Add(r6);

				Genre r7 = new Genre();
				r7.GenreName = "Fantasy";
				Genres.Add(r7);

				Genre r8 = new Genre();
				r8.GenreName = "Contemporary Fiction";
				Genres.Add(r8);

				Genre r9 = new Genre();
				r9.GenreName = "Romance";
				Genres.Add(r9);

				Genre r10 = new Genre();
				r10.GenreName = "Fantasy";
				Genres.Add(r10);

				Genre r11 = new Genre();
				r11.GenreName = "Historical Fiction";
				Genres.Add(r11);

				Genre r12 = new Genre();
				r12.GenreName = "Romance";
				Genres.Add(r12);

				Genre r13 = new Genre();
				r13.GenreName = "Historical Fiction";
				Genres.Add(r13);

				Genre r14 = new Genre();
				r14.GenreName = "Romance";
				Genres.Add(r14);

				Genre r15 = new Genre();
				r15.GenreName = "Fantasy";
				Genres.Add(r15);

				Genre r16 = new Genre();
				r16.GenreName = "Mystery";
				Genres.Add(r16);

				Genre r17 = new Genre();
				r17.GenreName = "Mystery";
				Genres.Add(r17);

				Genre r18 = new Genre();
				r18.GenreName = "Suspense";
				Genres.Add(r18);

				Genre r19 = new Genre();
				r19.GenreName = "Romance";
				Genres.Add(r19);

				Genre r20 = new Genre();
				r20.GenreName = "Contemporary Fiction";
				Genres.Add(r20);

				Genre r21 = new Genre();
				r21.GenreName = "Mystery";
				Genres.Add(r21);

				Genre r22 = new Genre();
				r22.GenreName = "Suspense";
				Genres.Add(r22);

				Genre r23 = new Genre();
				r23.GenreName = "Mystery";
				Genres.Add(r23);

				Genre r24 = new Genre();
				r24.GenreName = "Fantasy";
				Genres.Add(r24);

				Genre r25 = new Genre();
				r25.GenreName = "Suspense";
				Genres.Add(r25);

				Genre r26 = new Genre();
				r26.GenreName = "Romance";
				Genres.Add(r26);

				Genre r27 = new Genre();
				r27.GenreName = "Mystery";
				Genres.Add(r27);

				Genre r28 = new Genre();
				r28.GenreName = "Historical Fiction";
				Genres.Add(r28);

				Genre r29 = new Genre();
				r29.GenreName = "Mystery";
				Genres.Add(r29);

				Genre r30 = new Genre();
				r30.GenreName = "Romance";
				Genres.Add(r30);

				Genre r31 = new Genre();
				r31.GenreName = "Historical Fiction";
				Genres.Add(r31);

				Genre r32 = new Genre();
				r32.GenreName = "Fantasy";
				Genres.Add(r32);

				Genre r33 = new Genre();
				r33.GenreName = "Mystery";
				Genres.Add(r33);

				Genre r34 = new Genre();
				r34.GenreName = "Mystery";
				Genres.Add(r34);

				Genre r35 = new Genre();
				r35.GenreName = "Contemporary Fiction";
				Genres.Add(r35);

				Genre r36 = new Genre();
				r36.GenreName = "Contemporary Fiction";
				Genres.Add(r36);

				Genre r37 = new Genre();
				r37.GenreName = "Thriller";
				Genres.Add(r37);

				Genre r38 = new Genre();
				r38.GenreName = "Suspense";
				Genres.Add(r38);

				Genre r39 = new Genre();
				r39.GenreName = "Mystery";
				Genres.Add(r39);

				Genre r40 = new Genre();
				r40.GenreName = "Fantasy";
				Genres.Add(r40);

				Genre r41 = new Genre();
				r41.GenreName = "Suspense";
				Genres.Add(r41);

				Genre r42 = new Genre();
				r42.GenreName = "Mystery";
				Genres.Add(r42);

				Genre r43 = new Genre();
				r43.GenreName = "Mystery";
				Genres.Add(r43);

				Genre r44 = new Genre();
				r44.GenreName = "Fantasy";
				Genres.Add(r44);

				Genre r45 = new Genre();
				r45.GenreName = "Suspense";
				Genres.Add(r45);

				Genre r46 = new Genre();
				r46.GenreName = "Historical Fiction";
				Genres.Add(r46);

				Genre r47 = new Genre();
				r47.GenreName = "Contemporary Fiction";
				Genres.Add(r47);

				Genre r48 = new Genre();
				r48.GenreName = "Humor";
				Genres.Add(r48);

				Genre r49 = new Genre();
				r49.GenreName = "Fantasy";
				Genres.Add(r49);

				Genre r50 = new Genre();
				r50.GenreName = "Thriller";
				Genres.Add(r50);

				Genre r51 = new Genre();
				r51.GenreName = "Mystery";
				Genres.Add(r51);

				Genre r52 = new Genre();
				r52.GenreName = "Historical Fiction";
				Genres.Add(r52);

				Genre r53 = new Genre();
				r53.GenreName = "Mystery";
				Genres.Add(r53);

				Genre r54 = new Genre();
				r54.GenreName = "Thriller";
				Genres.Add(r54);

				Genre r55 = new Genre();
				r55.GenreName = "Romance";
				Genres.Add(r55);

				Genre r56 = new Genre();
				r56.GenreName = "Mystery";
				Genres.Add(r56);

				Genre r57 = new Genre();
				r57.GenreName = "Contemporary Fiction";
				Genres.Add(r57);

				Genre r58 = new Genre();
				r58.GenreName = "Romance";
				Genres.Add(r58);

				Genre r59 = new Genre();
				r59.GenreName = "Mystery";
				Genres.Add(r59);

				Genre r60 = new Genre();
				r60.GenreName = "Mystery";
				Genres.Add(r60);

				Genre r61 = new Genre();
				r61.GenreName = "Thriller";
				Genres.Add(r61);

				Genre r62 = new Genre();
				r62.GenreName = "Thriller";
				Genres.Add(r62);

				Genre r63 = new Genre();
				r63.GenreName = "Romance";
				Genres.Add(r63);

				Genre r64 = new Genre();
				r64.GenreName = "Romance";
				Genres.Add(r64);

				Genre r65 = new Genre();
				r65.GenreName = "Science Fiction";
				Genres.Add(r65);

				Genre r66 = new Genre();
				r66.GenreName = "Mystery";
				Genres.Add(r66);

				Genre r67 = new Genre();
				r67.GenreName = "Historical Fiction";
				Genres.Add(r67);

				Genre r68 = new Genre();
				r68.GenreName = "Suspense";
				Genres.Add(r68);

				Genre r69 = new Genre();
				r69.GenreName = "Mystery";
				Genres.Add(r69);

				Genre r70 = new Genre();
				r70.GenreName = "Fantasy";
				Genres.Add(r70);

				Genre r71 = new Genre();
				r71.GenreName = "Fantasy";
				Genres.Add(r71);

				Genre r72 = new Genre();
				r72.GenreName = "Romance";
				Genres.Add(r72);

				Genre r73 = new Genre();
				r73.GenreName = "Romance";
				Genres.Add(r73);

				Genre r74 = new Genre();
				r74.GenreName = "Romance";
				Genres.Add(r74);

				Genre r75 = new Genre();
				r75.GenreName = "Adventure";
				Genres.Add(r75);

				Genre r76 = new Genre();
				r76.GenreName = "Contemporary Fiction";
				Genres.Add(r76);

				Genre r77 = new Genre();
				r77.GenreName = "Suspense";
				Genres.Add(r77);

				Genre r78 = new Genre();
				r78.GenreName = "Mystery";
				Genres.Add(r78);

				Genre r79 = new Genre();
				r79.GenreName = "Mystery";
				Genres.Add(r79);

				Genre r80 = new Genre();
				r80.GenreName = "Fantasy";
				Genres.Add(r80);

				Genre r81 = new Genre();
				r81.GenreName = "Romance";
				Genres.Add(r81);

				Genre r82 = new Genre();
				r82.GenreName = "Fantasy";
				Genres.Add(r82);

				Genre r83 = new Genre();
				r83.GenreName = "Suspense";
				Genres.Add(r83);

				Genre r84 = new Genre();
				r84.GenreName = "Mystery";
				Genres.Add(r84);

				Genre r85 = new Genre();
				r85.GenreName = "Mystery";
				Genres.Add(r85);

				Genre r86 = new Genre();
				r86.GenreName = "Historical Fiction";
				Genres.Add(r86);

				Genre r87 = new Genre();
				r87.GenreName = "Mystery";
				Genres.Add(r87);

				Genre r88 = new Genre();
				r88.GenreName = "Mystery";
				Genres.Add(r88);

				Genre r89 = new Genre();
				r89.GenreName = "Mystery";
				Genres.Add(r89);

				Genre r90 = new Genre();
				r90.GenreName = "Contemporary Fiction";
				Genres.Add(r90);

				Genre r91 = new Genre();
				r91.GenreName = "Romance";
				Genres.Add(r91);

				Genre r92 = new Genre();
				r92.GenreName = "Mystery";
				Genres.Add(r92);

				Genre r93 = new Genre();
				r93.GenreName = "Suspense";
				Genres.Add(r93);

				Genre r94 = new Genre();
				r94.GenreName = "Suspense";
				Genres.Add(r94);

				Genre r95 = new Genre();
				r95.GenreName = "Contemporary Fiction";
				Genres.Add(r95);

				Genre r96 = new Genre();
				r96.GenreName = "Romance";
				Genres.Add(r96);

				Genre r97 = new Genre();
				r97.GenreName = "Mystery";
				Genres.Add(r97);

				Genre r98 = new Genre();
				r98.GenreName = "Mystery";
				Genres.Add(r98);

				Genre r99 = new Genre();
				r99.GenreName = "Suspense";
				Genres.Add(r99);

				Genre r100 = new Genre();
				r100.GenreName = "Fantasy";
				Genres.Add(r100);

				Genre r101 = new Genre();
				r101.GenreName = "Mystery";
				Genres.Add(r101);

				Genre r102 = new Genre();
				r102.GenreName = "Fantasy";
				Genres.Add(r102);

				Genre r103 = new Genre();
				r103.GenreName = "Fantasy";
				Genres.Add(r103);

				Genre r104 = new Genre();
				r104.GenreName = "Science Fiction";
				Genres.Add(r104);

				Genre r105 = new Genre();
				r105.GenreName = "Science Fiction";
				Genres.Add(r105);

				Genre r106 = new Genre();
				r106.GenreName = "Mystery";
				Genres.Add(r106);

				Genre r107 = new Genre();
				r107.GenreName = "Suspense";
				Genres.Add(r107);

				Genre r108 = new Genre();
				r108.GenreName = "Romance";
				Genres.Add(r108);

				Genre r109 = new Genre();
				r109.GenreName = "Mystery";
				Genres.Add(r109);

				Genre r110 = new Genre();
				r110.GenreName = "Romance";
				Genres.Add(r110);

				Genre r111 = new Genre();
				r111.GenreName = "Suspense";
				Genres.Add(r111);

				Genre r112 = new Genre();
				r112.GenreName = "Romance";
				Genres.Add(r112);

				Genre r113 = new Genre();
				r113.GenreName = "Horror";
				Genres.Add(r113);

				Genre r114 = new Genre();
				r114.GenreName = "Romance";
				Genres.Add(r114);

				Genre r115 = new Genre();
				r115.GenreName = "Mystery";
				Genres.Add(r115);

				Genre r116 = new Genre();
				r116.GenreName = "Suspense";
				Genres.Add(r116);

				Genre r117 = new Genre();
				r117.GenreName = "Mystery";
				Genres.Add(r117);

				Genre r118 = new Genre();
				r118.GenreName = "Suspense";
				Genres.Add(r118);

				Genre r119 = new Genre();
				r119.GenreName = "Mystery";
				Genres.Add(r119);

				Genre r120 = new Genre();
				r120.GenreName = "Romance";
				Genres.Add(r120);

				Genre r121 = new Genre();
				r121.GenreName = "Mystery";
				Genres.Add(r121);

				Genre r122 = new Genre();
				r122.GenreName = "Historical Fiction";
				Genres.Add(r122);

				Genre r123 = new Genre();
				r123.GenreName = "Fantasy";
				Genres.Add(r123);

				Genre r124 = new Genre();
				r124.GenreName = "Romance";
				Genres.Add(r124);

				Genre r125 = new Genre();
				r125.GenreName = "Mystery";
				Genres.Add(r125);

				Genre r126 = new Genre();
				r126.GenreName = "Mystery";
				Genres.Add(r126);

				Genre r127 = new Genre();
				r127.GenreName = "Horror";
				Genres.Add(r127);

				Genre r128 = new Genre();
				r128.GenreName = "Mystery";
				Genres.Add(r128);

				Genre r129 = new Genre();
				r129.GenreName = "Romance";
				Genres.Add(r129);

				Genre r130 = new Genre();
				r130.GenreName = "Fantasy";
				Genres.Add(r130);

				Genre r131 = new Genre();
				r131.GenreName = "Mystery";
				Genres.Add(r131);

				Genre r132 = new Genre();
				r132.GenreName = "Mystery";
				Genres.Add(r132);

				Genre r133 = new Genre();
				r133.GenreName = "Contemporary Fiction";
				Genres.Add(r133);

				Genre r134 = new Genre();
				r134.GenreName = "Science Fiction";
				Genres.Add(r134);

				Genre r135 = new Genre();
				r135.GenreName = "Mystery";
				Genres.Add(r135);

				Genre r136 = new Genre();
				r136.GenreName = "Suspense";
				Genres.Add(r136);

				Genre r137 = new Genre();
				r137.GenreName = "Suspense";
				Genres.Add(r137);

				Genre r138 = new Genre();
				r138.GenreName = "Suspense";
				Genres.Add(r138);

				Genre r139 = new Genre();
				r139.GenreName = "Suspense";
				Genres.Add(r139);

				Genre r140 = new Genre();
				r140.GenreName = "Romance";
				Genres.Add(r140);

				Genre r141 = new Genre();
				r141.GenreName = "Mystery";
				Genres.Add(r141);

				Genre r142 = new Genre();
				r142.GenreName = "Mystery";
				Genres.Add(r142);

				Genre r143 = new Genre();
				r143.GenreName = "Thriller";
				Genres.Add(r143);

				Genre r144 = new Genre();
				r144.GenreName = "Thriller";
				Genres.Add(r144);

				Genre r145 = new Genre();
				r145.GenreName = "Mystery";
				Genres.Add(r145);

				Genre r146 = new Genre();
				r146.GenreName = "Fantasy";
				Genres.Add(r146);

				Genre r147 = new Genre();
				r147.GenreName = "Humor";
				Genres.Add(r147);

				Genre r148 = new Genre();
				r148.GenreName = "Fantasy";
				Genres.Add(r148);

				Genre r149 = new Genre();
				r149.GenreName = "Suspense";
				Genres.Add(r149);

				Genre r150 = new Genre();
				r150.GenreName = "Historical Fiction";
				Genres.Add(r150);

				Genre r151 = new Genre();
				r151.GenreName = "Mystery";
				Genres.Add(r151);

				Genre r152 = new Genre();
				r152.GenreName = "Fantasy";
				Genres.Add(r152);

				Genre r153 = new Genre();
				r153.GenreName = "Thriller";
				Genres.Add(r153);

				Genre r154 = new Genre();
				r154.GenreName = "Historical Fiction";
				Genres.Add(r154);

				Genre r155 = new Genre();
				r155.GenreName = "Suspense";
				Genres.Add(r155);

				Genre r156 = new Genre();
				r156.GenreName = "Contemporary Fiction";
				Genres.Add(r156);

				Genre r157 = new Genre();
				r157.GenreName = "Contemporary Fiction";
				Genres.Add(r157);

				Genre r158 = new Genre();
				r158.GenreName = "Suspense";
				Genres.Add(r158);

				Genre r159 = new Genre();
				r159.GenreName = "Mystery";
				Genres.Add(r159);

				Genre r160 = new Genre();
				r160.GenreName = "Thriller";
				Genres.Add(r160);

				Genre r161 = new Genre();
				r161.GenreName = "Suspense";
				Genres.Add(r161);

				Genre r162 = new Genre();
				r162.GenreName = "Historical Fiction";
				Genres.Add(r162);

				Genre r163 = new Genre();
				r163.GenreName = "Mystery";
				Genres.Add(r163);

				Genre r164 = new Genre();
				r164.GenreName = "Mystery";
				Genres.Add(r164);

				Genre r165 = new Genre();
				r165.GenreName = "Suspense";
				Genres.Add(r165);

				Genre r166 = new Genre();
				r166.GenreName = "Mystery";
				Genres.Add(r166);

				Genre r167 = new Genre();
				r167.GenreName = "Romance";
				Genres.Add(r167);

				Genre r168 = new Genre();
				r168.GenreName = "Romance";
				Genres.Add(r168);

				Genre r169 = new Genre();
				r169.GenreName = "Fantasy";
				Genres.Add(r169);

				Genre r170 = new Genre();
				r170.GenreName = "Poetry";
				Genres.Add(r170);

				Genre r171 = new Genre();
				r171.GenreName = "Suspense";
				Genres.Add(r171);

				Genre r172 = new Genre();
				r172.GenreName = "Mystery";
				Genres.Add(r172);

				Genre r173 = new Genre();
				r173.GenreName = "Romance";
				Genres.Add(r173);

				Genre r174 = new Genre();
				r174.GenreName = "Horror";
				Genres.Add(r174);

				Genre r175 = new Genre();
				r175.GenreName = "Historical Fiction";
				Genres.Add(r175);

				Genre r176 = new Genre();
				r176.GenreName = "Romance";
				Genres.Add(r176);

				Genre r177 = new Genre();
				r177.GenreName = "Thriller";
				Genres.Add(r177);

				Genre r178 = new Genre();
				r178.GenreName = "Science Fiction";
				Genres.Add(r178);

				Genre r179 = new Genre();
				r179.GenreName = "Historical Fiction";
				Genres.Add(r179);

				Genre r180 = new Genre();
				r180.GenreName = "Mystery";
				Genres.Add(r180);

				Genre r181 = new Genre();
				r181.GenreName = "Suspense";
				Genres.Add(r181);

				Genre r182 = new Genre();
				r182.GenreName = "Suspense";
				Genres.Add(r182);

				Genre r183 = new Genre();
				r183.GenreName = "Mystery";
				Genres.Add(r183);

				Genre r184 = new Genre();
				r184.GenreName = "Historical Fiction";
				Genres.Add(r184);

				Genre r185 = new Genre();
				r185.GenreName = "Science Fiction";
				Genres.Add(r185);

				Genre r186 = new Genre();
				r186.GenreName = "Contemporary Fiction";
				Genres.Add(r186);

				Genre r187 = new Genre();
				r187.GenreName = "Contemporary Fiction";
				Genres.Add(r187);

				Genre r188 = new Genre();
				r188.GenreName = "Contemporary Fiction";
				Genres.Add(r188);

				Genre r189 = new Genre();
				r189.GenreName = "Mystery";
				Genres.Add(r189);

				Genre r190 = new Genre();
				r190.GenreName = "Fantasy";
				Genres.Add(r190);

				Genre r191 = new Genre();
				r191.GenreName = "Fantasy";
				Genres.Add(r191);

				Genre r192 = new Genre();
				r192.GenreName = "Fantasy";
				Genres.Add(r192);

				Genre r193 = new Genre();
				r193.GenreName = "Contemporary Fiction";
				Genres.Add(r193);

				Genre r194 = new Genre();
				r194.GenreName = "Fantasy";
				Genres.Add(r194);

				Genre r195 = new Genre();
				r195.GenreName = "Fantasy";
				Genres.Add(r195);

				Genre r196 = new Genre();
				r196.GenreName = "Suspense";
				Genres.Add(r196);

				Genre r197 = new Genre();
				r197.GenreName = "Historical Fiction";
				Genres.Add(r197);

				Genre r198 = new Genre();
				r198.GenreName = "Mystery";
				Genres.Add(r198);

				Genre r199 = new Genre();
				r199.GenreName = "Historical Fiction";
				Genres.Add(r199);

				Genre r200 = new Genre();
				r200.GenreName = "Contemporary Fiction";
				Genres.Add(r200);

				Genre r201 = new Genre();
				r201.GenreName = "Historical Fiction";
				Genres.Add(r201);

				Genre r202 = new Genre();
				r202.GenreName = "Mystery";
				Genres.Add(r202);

				Genre r203 = new Genre();
				r203.GenreName = "Mystery";
				Genres.Add(r203);

				Genre r204 = new Genre();
				r204.GenreName = "Mystery";
				Genres.Add(r204);

				Genre r205 = new Genre();
				r205.GenreName = "Mystery";
				Genres.Add(r205);

				Genre r206 = new Genre();
				r206.GenreName = "Romance";
				Genres.Add(r206);

				Genre r207 = new Genre();
				r207.GenreName = "Suspense";
				Genres.Add(r207);

				Genre r208 = new Genre();
				r208.GenreName = "Suspense";
				Genres.Add(r208);

				Genre r209 = new Genre();
				r209.GenreName = "Mystery";
				Genres.Add(r209);

				Genre r210 = new Genre();
				r210.GenreName = "Poetry";
				Genres.Add(r210);

				Genre r211 = new Genre();
				r211.GenreName = "Thriller";
				Genres.Add(r211);

				Genre r212 = new Genre();
				r212.GenreName = "Contemporary Fiction";
				Genres.Add(r212);

				Genre r213 = new Genre();
				r213.GenreName = "Humor";
				Genres.Add(r213);

				Genre r214 = new Genre();
				r214.GenreName = "Romance";
				Genres.Add(r214);

				Genre r215 = new Genre();
				r215.GenreName = "Romance";
				Genres.Add(r215);

				Genre r216 = new Genre();
				r216.GenreName = "Suspense";
				Genres.Add(r216);

				Genre r217 = new Genre();
				r217.GenreName = "Mystery";
				Genres.Add(r217);

				Genre r218 = new Genre();
				r218.GenreName = "Historical Fiction";
				Genres.Add(r218);

				Genre r219 = new Genre();
				r219.GenreName = "Historical Fiction";
				Genres.Add(r219);

				Genre r220 = new Genre();
				r220.GenreName = "Romance";
				Genres.Add(r220);

				Genre r221 = new Genre();
				r221.GenreName = "Mystery";
				Genres.Add(r221);

				Genre r222 = new Genre();
				r222.GenreName = "Thriller";
				Genres.Add(r222);

				Genre r223 = new Genre();
				r223.GenreName = "Science Fiction";
				Genres.Add(r223);

				Genre r224 = new Genre();
				r224.GenreName = "Mystery";
				Genres.Add(r224);

				Genre r225 = new Genre();
				r225.GenreName = "Historical Fiction";
				Genres.Add(r225);

				Genre r226 = new Genre();
				r226.GenreName = "Historical Fiction";
				Genres.Add(r226);

				Genre r227 = new Genre();
				r227.GenreName = "Romance";
				Genres.Add(r227);

				Genre r228 = new Genre();
				r228.GenreName = "Mystery";
				Genres.Add(r228);

				Genre r229 = new Genre();
				r229.GenreName = "Thriller";
				Genres.Add(r229);

				Genre r230 = new Genre();
				r230.GenreName = "Mystery";
				Genres.Add(r230);

				Genre r231 = new Genre();
				r231.GenreName = "Romance";
				Genres.Add(r231);

				Genre r232 = new Genre();
				r232.GenreName = "Suspense";
				Genres.Add(r232);

				Genre r233 = new Genre();
				r233.GenreName = "Mystery";
				Genres.Add(r233);

				Genre r234 = new Genre();
				r234.GenreName = "Thriller";
				Genres.Add(r234);

				Genre r235 = new Genre();
				r235.GenreName = "Suspense";
				Genres.Add(r235);

				Genre r236 = new Genre();
				r236.GenreName = "Mystery";
				Genres.Add(r236);

				Genre r237 = new Genre();
				r237.GenreName = "Science Fiction";
				Genres.Add(r237);

				Genre r238 = new Genre();
				r238.GenreName = "Suspense";
				Genres.Add(r238);

				Genre r239 = new Genre();
				r239.GenreName = "Mystery";
				Genres.Add(r239);

				Genre r240 = new Genre();
				r240.GenreName = "Suspense";
				Genres.Add(r240);

				Genre r241 = new Genre();
				r241.GenreName = "Contemporary Fiction";
				Genres.Add(r241);

				Genre r242 = new Genre();
				r242.GenreName = "Contemporary Fiction";
				Genres.Add(r242);

				Genre r243 = new Genre();
				r243.GenreName = "Mystery";
				Genres.Add(r243);

				Genre r244 = new Genre();
				r244.GenreName = "Mystery";
				Genres.Add(r244);

				Genre r245 = new Genre();
				r245.GenreName = "Thriller";
				Genres.Add(r245);

				Genre r246 = new Genre();
				r246.GenreName = "Contemporary Fiction";
				Genres.Add(r246);

				Genre r247 = new Genre();
				r247.GenreName = "Historical Fiction";
				Genres.Add(r247);

				Genre r248 = new Genre();
				r248.GenreName = "Fantasy";
				Genres.Add(r248);

				Genre r249 = new Genre();
				r249.GenreName = "Contemporary Fiction";
				Genres.Add(r249);

				Genre r250 = new Genre();
				r250.GenreName = "Mystery";
				Genres.Add(r250);

				Genre r251 = new Genre();
				r251.GenreName = "Suspense";
				Genres.Add(r251);

				Genre r252 = new Genre();
				r252.GenreName = "Romance";
				Genres.Add(r252);

				Genre r253 = new Genre();
				r253.GenreName = "Contemporary Fiction";
				Genres.Add(r253);

				Genre r254 = new Genre();
				r254.GenreName = "Suspense";
				Genres.Add(r254);

				Genre r255 = new Genre();
				r255.GenreName = "Fantasy";
				Genres.Add(r255);

				Genre r256 = new Genre();
				r256.GenreName = "Suspense";
				Genres.Add(r256);

				Genre r257 = new Genre();
				r257.GenreName = "Mystery";
				Genres.Add(r257);

				Genre r258 = new Genre();
				r258.GenreName = "Suspense";
				Genres.Add(r258);

				Genre r259 = new Genre();
				r259.GenreName = "Historical Fiction";
				Genres.Add(r259);

				Genre r260 = new Genre();
				r260.GenreName = "Science Fiction";
				Genres.Add(r260);

				Genre r261 = new Genre();
				r261.GenreName = "Romance";
				Genres.Add(r261);

				Genre r262 = new Genre();
				r262.GenreName = "Suspense";
				Genres.Add(r262);

				Genre r263 = new Genre();
				r263.GenreName = "Fantasy";
				Genres.Add(r263);

				Genre r264 = new Genre();
				r264.GenreName = "Historical Fiction";
				Genres.Add(r264);

				Genre r265 = new Genre();
				r265.GenreName = "Suspense";
				Genres.Add(r265);

				Genre r266 = new Genre();
				r266.GenreName = "Mystery";
				Genres.Add(r266);

				Genre r267 = new Genre();
				r267.GenreName = "Fantasy";
				Genres.Add(r267);

				Genre r268 = new Genre();
				r268.GenreName = "Suspense";
				Genres.Add(r268);

				Genre r269 = new Genre();
				r269.GenreName = "Mystery";
				Genres.Add(r269);

				Genre r270 = new Genre();
				r270.GenreName = "Mystery";
				Genres.Add(r270);

				Genre r271 = new Genre();
				r271.GenreName = "Thriller";
				Genres.Add(r271);

				Genre r272 = new Genre();
				r272.GenreName = "Contemporary Fiction";
				Genres.Add(r272);

				Genre r273 = new Genre();
				r273.GenreName = "Suspense";
				Genres.Add(r273);

				Genre r274 = new Genre();
				r274.GenreName = "Mystery";
				Genres.Add(r274);

				Genre r275 = new Genre();
				r275.GenreName = "Mystery";
				Genres.Add(r275);

				Genre r276 = new Genre();
				r276.GenreName = "Mystery";
				Genres.Add(r276);

				Genre r277 = new Genre();
				r277.GenreName = "Thriller";
				Genres.Add(r277);

				Genre r278 = new Genre();
				r278.GenreName = "Mystery";
				Genres.Add(r278);

				Genre r279 = new Genre();
				r279.GenreName = "Mystery";
				Genres.Add(r279);

				Genre r280 = new Genre();
				r280.GenreName = "Suspense";
				Genres.Add(r280);

				Genre r281 = new Genre();
				r281.GenreName = "Contemporary Fiction";
				Genres.Add(r281);

				Genre r282 = new Genre();
				r282.GenreName = "Mystery";
				Genres.Add(r282);

				Genre r283 = new Genre();
				r283.GenreName = "Mystery";
				Genres.Add(r283);

				Genre r284 = new Genre();
				r284.GenreName = "Science Fiction";
				Genres.Add(r284);

				Genre r285 = new Genre();
				r285.GenreName = "Thriller";
				Genres.Add(r285);

				Genre r286 = new Genre();
				r286.GenreName = "Mystery";
				Genres.Add(r286);

				Genre r287 = new Genre();
				r287.GenreName = "Fantasy";
				Genres.Add(r287);

				Genre r288 = new Genre();
				r288.GenreName = "Fantasy";
				Genres.Add(r288);

				Genre r289 = new Genre();
				r289.GenreName = "Mystery";
				Genres.Add(r289);

				Genre r290 = new Genre();
				r290.GenreName = "Contemporary Fiction";
				Genres.Add(r290);

				Genre r291 = new Genre();
				r291.GenreName = "Mystery";
				Genres.Add(r291);

				Genre r292 = new Genre();
				r292.GenreName = "Science Fiction";
				Genres.Add(r292);

				Genre r293 = new Genre();
				r293.GenreName = "Mystery";
				Genres.Add(r293);

				Genre r294 = new Genre();
				r294.GenreName = "Suspense";
				Genres.Add(r294);

				Genre r295 = new Genre();
				r295.GenreName = "Shakespeare";
				Genres.Add(r295);

				Genre r296 = new Genre();
				r296.GenreName = "Mystery";
				Genres.Add(r296);

				Genre r297 = new Genre();
				r297.GenreName = "Historical Fiction";
				Genres.Add(r297);

				Genre r298 = new Genre();
				r298.GenreName = "Romance";
				Genres.Add(r298);

				Genre r299 = new Genre();
				r299.GenreName = "Contemporary Fiction";
				Genres.Add(r299);

				Genre r300 = new Genre();
				r300.GenreName = "Mystery";
				Genres.Add(r300);

				//loop through genres
				foreach (Genre genre in Genres)
				{
					//set name of repo to help debug
					genreName = genre.GenreName;

					//see if repo exists in database
					Genre dbGenre = db.Genres.FirstOrDefault(r => r.GenreName == genre.GenreName);

					if (dbGenre == null) //genre does not exist in database
					{
						db.Genres.Add(genre);
						db.SaveChanges();
						intGenresAdded += 1;
					}
					else
					{
						dbGenre.GenreName = genre.GenreName;
						db.Update(dbGenre);
						db.SaveChanges();
					}
				}
			}
			catch
			{
				String msg = "Genres added:" + intGenresAdded + "; Error on " + genreName;
				throw new InvalidOperationException(msg);
			}
		}
	}
}
